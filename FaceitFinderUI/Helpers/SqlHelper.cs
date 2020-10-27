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
            var avatar = user.Avatar;
            dynamic parameters = new
            {

                Nickname = user.Nickname,
                Email = user.Email,
                Password = user.Password,
                Avatar = avatar,
                PlayerId = user.Playerid
                

            };
            string sql = GetSqlQuery("InsertIntoUsers");
            await _sqlData.SaveData<dynamic>(sql, parameters);
        }

        public async Task SaveUserStats(FaceitUserModel faceitUser)
        {
            //string sql = @"Insert into "
            string sql = GetSqlQuery("InsertIntoFaceitStats");
            dynamic parameters = new
            {
                Playerid = faceitUser.player_id,
                FavoriteMapId = faceitUser.FavoriteMap,
                GameId = faceitUser.game_id,
                FavoriteMapImg = _converter.GetImgByUrl(faceitUser.MapImg),
                AverageHeadshots = faceitUser.lifetime.AverageHeadshots,
                Kd = faceitUser.lifetime.Kd,
                LongestWinStreak = faceitUser.lifetime.Longest_Win_Streak,
                Matches = faceitUser.lifetime.Matches,
                Wr = faceitUser.lifetime.WR,
                Wins = faceitUser.lifetime.Wins
            };
          await  _sqlData.SaveData(sql, parameters);
        }
    }
}
//public int Id { get; set; }
//public string Nickname { get; set; }
//public string Email { get; set; }
//public string Password { get; set; }