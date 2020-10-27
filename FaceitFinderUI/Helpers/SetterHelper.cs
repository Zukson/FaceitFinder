using AutoMapper;
using AutoMapper.Mappers;
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
        IMapper _mapper;
        public SetterHelper(IApiHelper apiHelper,IMapper mapper)
        {
            _apiHelper = apiHelper;
            _mapper = mapper;
        }
        public async Task SetUser(string mail, string password, string username, byte[] Avatar, UserModel user)
        {
            user.Email = mail;
            user.Password = password;
            user.Nickname = username;
            user.Avatar = Avatar;
            var player = await _apiHelper.GetPlayerInfo(username);
            user.Playerid = player.player_id;

        }

        public async Task<FaceitUserModel> SetUserStats( string id)
        {
           var output  = _mapper.Map<FaceitUserModel>(await _apiHelper.GetFaceitUserById(id));

            return output;


        }
    }
}
