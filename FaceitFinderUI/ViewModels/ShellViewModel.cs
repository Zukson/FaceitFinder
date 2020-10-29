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
        private ProfileViewModel _profile;
        private SearchViewModel _search;
    public   ShellViewModel(LoginViewModel login,
                            RegisterViewModel register,
                            LogOnEvent logOnEvent,
                            RegisterEvent registerEvent,
                            ProfileViewModel profile,
                            SearchViewModel search)
        {
            _register = register;
            _login = login;
            _search = search;
            ActivateItem(_login) ;
            _logOnEvent = logOnEvent;
            _logOnEvent.LogInEvent += Login;
            TextBlockClickEvent.RegisterClicked += RegisterTextBlockClicked;
            TextBlockClickEvent.SearchClicked += SearchTexBlockClicked;
            _registerEvent = registerEvent;
            _registerEvent.Registered += Registered;
            _profile = profile;
            
         
        }

        public void Login()
        {
            ActivateItem(_profile);
        }
        public void Registered()
        {
            ActivateItem(_login);
        }
        public void RegisterTextBlockClicked()
        {
            ActivateItem(_register);
        }
        public void SearchTexBlockClicked()
        {
            ActivateItem(_search);
        }
    }
}
