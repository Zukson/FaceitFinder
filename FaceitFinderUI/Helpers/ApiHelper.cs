using ApiLibrary.Api;
using ApiLibrary.Models;
using FaceitFinderUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FaceitFinderUI.Helpers
{
   public   class ApiHelper
    {
       private  readonly IFaceitApi _api;
        public ApiHelper(IFaceitApi api)
        {

        }
        public async Task<string> GetPlayerId(string username) {

           return  await _api.GetPlayerIdByName(username);
        }
        public async Task<FaceitCsgoModel>GetFaceitUserById(string id)
        {
            return await _api.GetStatsByPlayerId(id);
        }


    }
}
