using FaceitFinderUI.Models;
using SqlLibrary.DataAccess;
using SqlLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceitFinderUI.Helpers
{
    public class SqlHelper : ISqlHelper
    {
        private ISqlData _sqlData;
        private IConverter _converter;
        public SqlHelper(ISqlData sqlData,IConverter converter)
        {
            _sqlData = sqlData;
            _converter = converter;
        }
        private string GetSqlQuery(string name)
        {
           return ConfigurationManager.AppSettings[name];
        }

        public async Task<List<UserSqlModel>> GetPlayers()
        {
            var output = await _sqlData.GetAllUsers<UserSqlModel>(GetSqlQuery("GetAllUsers"));

            return output.ToList();

        }
        public async Task<UserSqlModel> GetPlayerByLoginData(string mail,string password)
        {
            var output = await _sqlData.GetAllUsers<UserSqlModel>(GetSqlQuery("GetAllUsers"));
                  
            return output.Where(x => x.Email== mail&&x.Password==password).First();

        }

        public async Task SaveUser(UserModel user)
        {
            var avatar = _converter.ConvertBitmapImageToBytes(user.Avatar);
            dynamic parameters = new
            {

                Nickname = user.Nickname,
                Email = user.Email,
                Password = user.Password,
                Avatar = avatar
                

            };
            string sql = @"Insert into Users (Nickname,Email,Password,Avatar) values (@Nickname,@Email,@Password,@Avatar)";
            await _sqlData.SaveData<dynamic>(sql, parameters);
        }
    }
}
//public int Id { get; set; }
//public string Nickname { get; set; }
//public string Email { get; set; }
//public string Password { get; set; }