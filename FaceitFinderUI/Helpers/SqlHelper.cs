using SqlLibrary.DataAccess;
using SqlLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceitFinderUI.Helpers
{
    class SqlHelper
    {
        private ISqlData _sqlData;
        public SqlHelper(ISqlData sqlData)
        {
            _sqlData = sqlData;
        }


       async Task<List<UserSqlModel>> GetPlayers ()
        {
            var output = await _sqlData.GetAllUsers<UserSqlModel>(_sqlData.GetConnectionString("DB"));

            return output.ToList();

        }
        async Task<UserSqlModel> GetPlayerById(int id)
        {
            var output = await _sqlData.GetAllUsers<UserSqlModel>(_sqlData.GetConnectionString("DB"));

            return output.Where(x => x.Id == id).First();

        }

        async Task SaveUser(UserSqlModel user)  
        { 
            dynamic parameters = new
            {
                Id=user.Id
            }
            _sqlData.SaveData<UserSqlModel>(" ", user);
        }
    }
}
