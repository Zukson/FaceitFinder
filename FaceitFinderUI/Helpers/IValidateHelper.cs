using FaceitFinderUI.Models;
using System.Collections.Generic;

namespace FaceitFinderUI.Helpers
{
    public interface IValidateHelper
    {
        bool CheckEmail(string email);
        bool CheckPassword(string password);
        bool CheckUsername(string username);
        Errors IsDataValid(string username, string email, string password);
        bool IsUsernameFree(string username, List<UserModel> users);
        bool IsEmailFree(string email, List<UserModel> users);
    }
}