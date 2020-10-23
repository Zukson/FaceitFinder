using Caliburn.Micro;
using FaceitFinderUI.Events;
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
      
    public   ShellViewModel(LoginViewModel login,RegisterViewModel register,LogOnEvent logOnEvent)
        {
            _register = register;
            _login = login;
            ActivateItem(_register) ;
            _logOnEvent = logOnEvent;
            _logOnEvent.LogInEvent += Login;
            CreateAccountTextBlockEvent.Clicked += RegisterTextBlockClicked; 
         
        }

        public void Login()
        {
            ActivateItem(_register);
        }
        public void RegisterTextBlockClicked()
        {
            ActivateItem(_register);
        }
    }
}
