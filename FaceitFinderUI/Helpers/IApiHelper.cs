using ApiLibrary.Models;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FaceitFinderUI.Helpers
{
    public interface IApiHelper
    {
        Task<FaceitCsgoModel> GetFaceitUserById(string id);
        Task<FaceitPlayerModel> GetPlayerInfo(string username);
        Task<byte[]> GetUserAvatar(string nickname);
    }
}