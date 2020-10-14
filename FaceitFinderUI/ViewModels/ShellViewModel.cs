using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.ViewModels
{
   class ShellViewModel :Conductor<object>
    {
        private LoginViewModel _login;
    public   ShellViewModel(LoginViewModel login)
        {
            _login = login;
            ActivateItem(_login) ;
        }
    }
}
