using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.ViewModels
{
   class ShellViewModel :Conductor<object>
    {
        private RegisterViewModel _register;
        private LoginViewModel _login;
    public   ShellViewModel(LoginViewModel login,RegisterViewModel register)
        {
            _register = register;
            _login = login;
            ActivateItem(_login) ;
        }
    }
}
