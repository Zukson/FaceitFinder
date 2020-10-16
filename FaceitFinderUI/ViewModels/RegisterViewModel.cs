using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.ViewModels
{
  public   class RegisterViewModel : Screen
    {
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
		public async void Register()
		{

		}

	}

}
