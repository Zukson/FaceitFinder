using ApiLibrary.Api;
using ApiLibrary.Models;
using FaceitFinderUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FaceitFinderUI.Helpers
{
    public class ApiHelper : IApiHelper
    {
        private readonly IFaceitApi _api;
        public ApiHelper(IFaceitApi api)
        {
            _api = api;
        }
        public async Task<FaceitPlayerModel> GetPlayerInfo(string username)
        {

            return await _api.GetPlayerInformationsByName(username);
        }
        public async Task<FaceitCsgoModel> GetFaceitUserById(string id)
        {
            return await _api.GetStatsByPlayerId(id);
        }


    }
}
