using FaceitFinderUI.Models;
using SqlLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FaceitFinderUI.Helpers
{
    public interface ISqlHelper
    {
        Task<UserSqlModel> GetPlayerByLoginData(string mail,string password);
        Task<List<UserSqlModel>> GetPlayers();
        Task SaveUser(UserModel user);
    }
}