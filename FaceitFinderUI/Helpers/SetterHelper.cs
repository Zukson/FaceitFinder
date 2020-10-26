using FaceitFinderUI.Models;
using System;
using System.Collections.Generic;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FaceitFinderUI.Helpers
{
    public class SetterHelper : ISetterHelper
    {
        IApiHelper _apiHelper;
        public SetterHelper(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task SetUser(string mail, string password, string username, byte[] Avatar,UserModel user)
        {
            user.Email = mail;
            user.Password = password;
            user.Nickname = username;
            user.Avatar = Avatar;
            var player = await _apiHelper.GetPlayerInfo(username);
            user.Playerid = player.player_id;

        }

        public async Task SetUserStats(FaceitUserModel userModel,string id)
        {
            var apiOutput = await _apiHelper.GetFaceitUserById(id);

            userModel.

        }
    }
}
