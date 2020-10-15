using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.ViewModels
{
  public    class LoginViewModel:Screen
    {

        public LoginViewModel()
        {

        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set {
                
                
                _username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanLogin);
            
            
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { 
                
                _password = value;


                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }


        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set {
                
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
            
            }

           
        }

        public bool CanLogin
        {
            get
            {
                bool output = false;
                if(Password?.Length >0&&Username?.Length>0)
                {
                    output = true;
                }
                return output;

            }
        }
        public async void Login()
        {
            //TODO logika logowania
        }

    }
}
