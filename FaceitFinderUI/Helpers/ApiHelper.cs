using ApiLibrary.Api;
using ApiLibrary.Models;
using FaceitFinderUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FaceitFinderUI.Helpers
{
    public class ApiHelper : IApiHelper
    {
        private readonly IFaceitApi _api;
        IConverter _converter;
        public ApiHelper(IFaceitApi api ,IConverter converter)
        {
            _api = api;
            _converter = converter;
        }
        public async Task<FaceitPlayerModel> GetPlayerInfo(string username)
        {

            return await _api.GetPlayerInformationsByName(username);
        }
        public async Task<FaceitCsgoModel> GetFaceitUserById(string id)
        {
            return await _api.GetStatsByPlayerId(id);
        }
        public async Task<BitmapImage> GetUserAvatar(string nickname)
        {
            var user = await GetPlayerInfo(nickname);

            BitmapImage bitmap = _converter.GetImgByUrl(user.avatar);
            return bitmap;

        }


    }
}
