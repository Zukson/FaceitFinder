using Caliburn.Micro;
using FaceitFinderUI.Events;
using FaceitFinderUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.ViewModels
{
   class ShellViewModel :Conductor<object>
    {
        private RegisterViewModel _register;
        private LoginViewModel _login;
        private LogOnEvent _logOnEvent;
        private RegisterEvent _registerEvent;
   
    public   ShellViewModel(LoginViewModel login,RegisterViewModel register,LogOnEvent logOnEvent, RegisterEvent registerEvent)
        {
            _register = register;
            _login = login;
            ActivateItem(_register) ;
            _logOnEvent = logOnEvent;
            _logOnEvent.LogInEvent += Login;
            CreateAccountTextBlockEvent.Clicked += RegisterTextBlockClicked;
            _registerEvent = registerEvent;
            _registerEvent.Registered += Registered;
         
        }

        public void Login()
        {
            ActivateItem(_register);
        }
        public void Registered()
        {
            ActivateItem(_login);
        }
        public void RegisterTextBlockClicked()
        {
            ActivateItem(_register);
        }
    }
}
