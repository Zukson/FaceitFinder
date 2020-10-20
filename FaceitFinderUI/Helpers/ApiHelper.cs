using ApiLibrary.Api;
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

    }
}
