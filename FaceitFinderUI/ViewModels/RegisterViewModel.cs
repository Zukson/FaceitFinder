using AutoMapper;
using Caliburn.Micro;
using FaceitFinderUI.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.ViewModels
{
  public   class RegisterViewModel : Screen
    {
		
		private readonly IValidateHelper _validate;
		IMapper _mapper;
		public RegisterViewModel(IValidateHelper validate,IMapper mapper)
		{
			_validate = validate;
			_mapper = mapper;
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

		private void  IsValid()
		{
		var output=	_validate.IsDataValid(FaceitUsername, Mail, Password);
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
				IsValid();


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
