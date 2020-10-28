using FaceitFinderUI.Models;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FaceitFinderUI.Helpers
{
    public interface ISetterHelper
    {
        Task SetUser(string mail, string password, string username, byte[] Avatar, UserModel user);
        Task SetUserStats( string id,FaceitUserModel fm);
    }
}