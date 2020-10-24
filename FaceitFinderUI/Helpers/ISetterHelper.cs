using System.Windows.Media.Imaging;

namespace FaceitFinderUI.Helpers
{
    public interface ISetterHelper
    {
        void SetUser(string mail, string password, string username, BitmapImage Avatar);
    }
}