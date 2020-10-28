using ApiLibrary.Api;
using AutoMapper;
using Caliburn.Micro;
using FaceitFinderUI.Events;
using FaceitFinderUI.Helpers;
using FaceitFinderUI.Models;
using SqlLibrary.DataAccess;
using SqlLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FaceitFinderUI.ViewModels
{
  public    class LoginViewModel:Screen
    {
        private readonly ISqlHelper _sqlHelper;
        private LogOnEvent _logOnEvent;
        private readonly IValidateHelper _validate;
        IFaceitApi _api;
        UserModel _user;
        IMapper _mapper;
        FaceitUserModel _faceitUser;
        public LoginViewModel(
            ISqlHelper sqlHelper,
            LogOnEvent logOnEvent,
            IValidateHelper validate,
            IFaceitApi api,
            UserModel user,
            IMapper mapper,
            FaceitUserModel faceitUser)
        {
            _sqlHelper = sqlHelper;
            _logOnEvent = logOnEvent;
            _validate=validate;
            _api = api;
            _user = user;
            _mapper = mapper;
            _faceitUser = faceitUser;
         

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
                NotifyOfPropertyChange(() => IsErrorVisible);
            
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
        public async void Login()
        {
            ErrorMessage = null;
            try
            {
           _user = _mapper.Map<UserModel>(  await _validate.CheckLoginData(Username, Password));

                _faceitUser = _mapper.Map<FaceitUserModel>(await _api.GetStatsByPlayerId(_user.Playerid));
            }
           
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
       
        }

    }
}
