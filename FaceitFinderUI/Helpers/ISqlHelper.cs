using SqlLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FaceitFinderUI.Helpers
{
    public interface ISqlHelper
    {
        Task<UserSqlModel> GetPlayerById(int id);
        Task<List<UserSqlModel>> GetPlayers();
        Task SaveUser(UserSqlModel user);
    }
}