using AutoMapper;
using Caliburn.Micro;
using FaceitFinderUI.Helpers;
using FaceitFinderUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FaceitFinderUI.ViewModels
{
	public class RegisterViewModel : Screen
	{

		private readonly IValidateHelper _validate;
		IMapper _mapper;
		ISqlHelper _sql;
		UserModel _currentPlayer;
		IApiHelper _apiHelper;
		IConverter _converter;
		ISetterHelper _setter;
		
		public RegisterViewModel(IValidateHelper validate,IMapper mapper,ISqlHelper sql,IApiHelper apiHelper,UserModel player,IConverter converter,ISetterHelper setter)
		{
			_validate = validate;
			_mapper = mapper;
			_sql = sql;
			_currentPlayer = player;
			_apiHelper = apiHelper;
			_converter = converter;
			_setter = setter;
		}

		
		
		private string _errorMessage;

		public string ErrorMessage
		{
			get { return _errorMessage; }
			set
			{

				_errorMessage = value;
				NotifyOfPropertyChange(() => ErrorMessage);
				NotifyOfPropertyChange(() => IsErrorVisible);

			}


		}
		private string _mail;
		public string Mail
		{
			get { return _mail; }
			set { 
				_mail = value;
				NotifyOfPropertyChange(() => Mail);
				NotifyOfPropertyChange(() => CanRegister);

			}
		}
		private string _faceitUsername;

		public string FaceitUsername
		{
			get { return _faceitUsername; }
			set { 
				_faceitUsername = value;
				NotifyOfPropertyChange(() => FaceitUsername);
				NotifyOfPropertyChange(() => CanRegister);

			}
		}


		private string _password;

		public string Password
		{
			get { return _password; }
			set {
				_password = value;
				NotifyOfPropertyChange(() => Password);
				NotifyOfPropertyChange(() => CanRegister);

			}
		}
		public bool CanRegister
		{
			get
			{
				bool output = false;

				if (Password?.Length>0&& FaceitUsername?.Length>0&& Mail?.Length>0)
				{
					output = true;
				}
				return output;
			}
		}

		
		
		private  async Task IsValid()
		{
		var output   =	_validate.IsDataValid(FaceitUsername, Mail, Password, _mapper.Map<List<UserModel>>(await _sql.GetPlayers() ));
			if(output == Errors.Email)
			{
				throw new ArgumentException("Email nie jest prawidlowy ");
			}
			if(output == Errors.Nickname)
			{
				throw new ArgumentException("Nickname nie jest prawidlowy ");
			}
			if(output==Errors.Password)
			{
				throw new ArgumentException("Haslo nie spelnia norm");
			}
			if(output==Errors.EmailReserverd)
			{
				throw new Exception("Konto z takim mailem juz istnieje");

			}
			if(output==Errors.NicknameReserved)
			{
				throw new Exception("Konto z taka nazwa juz istnieje");
			}

		}
		public bool IsErrorVisible
		{

			get
			{
				bool output = false;
				if (ErrorMessage?.Length > 0)
				{
					output = true;
				}
				return output;
			}

			set

			{

			}



		}
		
		public async void Register()
		{
			try
			{
				await IsValid();
				 _setter.SetUser(Mail,Password,FaceitUsername,await _apiHelper.GetUserAvatar(FaceitUsername));
				await _sql.SaveUser(_currentPlayer);
				


			}
			catch(ArgumentException ex)
			{
				ErrorMessage = ex.Message;
			}
			catch(Exception ex)
			{
				ErrorMessage = ex.Message;
			}

		}

	}

}
