using SqlLibrary.DataAccess;
using SqlLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceitFinderUI.Helpers
{
    public class SqlHelper : ISqlHelper
    {
        private ISqlData _sqlData;
        public SqlHelper(ISqlData sqlData)
        {
            _sqlData = sqlData;
        }


        public async Task<List<UserSqlModel>> GetPlayers()
        {
            var output = await _sqlData.GetAllUsers<UserSqlModel>(_sqlData.GetConnectionString("DB"));

            return output.ToList();

        }
        public async Task<UserSqlModel> GetPlayerById(int id)
        {
            var output = await _sqlData.GetAllUsers<UserSqlModel>(_sqlData.GetConnectionString("DB"));

            return output.Where(x => x.Id == id).First();

        }

        public async Task SaveUser(UserSqlModel user)
        {
            dynamic parameters = new
            {
                Id = user.Id,
                Nickname = user.Nickname,
                Email = user.Email,
                Password = user.Password


            };
            string sql = @"Insert into Users (Nickname,Email,Password) values (@Nickname,@Email,@Password)";
            await _sqlData.SaveData<dynamic>(sql, user);
        }
    }
}
//public int Id { get; set; }
//public string Nickname { get; set; }
//public string Email { get; set; }
//public string Password { get; set; }