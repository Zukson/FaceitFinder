using ApiLibrary.Models;
using System.Threading.Tasks;

namespace FaceitFinderUI.Helpers
{
    public interface IApiHelper
    {
        Task<FaceitCsgoModel> GetFaceitUserById(string id);
        Task<FaceitPlayerModel> GetPlayerInfo(string username);
    }
}