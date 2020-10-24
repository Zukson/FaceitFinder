using FaceitFinderUI.Models;
using System;
using System.Collections.Generic;
using System.Security.RightsManagement;
using System.Text;
using System.Windows.Media.Imaging;

namespace FaceitFinderUI.Helpers
{
    public class SetterHelper : ISetterHelper
    {
        UserModel _user;
        public SetterHelper(UserModel user)
        {
            _user = user;
        }
        public void SetUser(string mail, string password, string username, BitmapImage Avatar)
        {
            _user.Email = mail;
            _user.Password = password;
            _user.Nickname = username;
            _user.Avatar = Avatar;

        }
    }
}
