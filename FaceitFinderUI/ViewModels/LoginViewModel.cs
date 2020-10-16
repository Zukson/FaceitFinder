using Caliburn.Micro;
using FaceitFinderUI.Events;
using FaceitFinderUI.Helpers;
using SqlLibrary.DataAccess;
using SqlLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.ViewModels
{
  public    class LoginViewModel:Screen
    {
        private readonly ISqlHelper _sqlHelper;
        private LogOnEvent _logOnEvent;
        public LoginViewModel(ISqlHelper sqlHelper, LogOnEvent logOnEvent )
        {
            _sqlHelper = sqlHelper;
            _logOnEvent = logOnEvent;
         

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
            _logOnEvent.LogIn();
            //try
            //{
            //    await _sqlHelper.SaveUser(new UserSqlModel
            //    {
            //        Email = "Kornio@wp.pl",
            //        Nickname = "KornioxPompa",
            //        Password = "Kornio3002"
            //    });
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
            //TODO logika logowania
        }

    }
}
