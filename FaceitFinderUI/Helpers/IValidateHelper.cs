using FaceitFinderUI.Models;
using System.Collections.Generic;

namespace FaceitFinderUI.Helpers
{
    public interface IValidateHelper
    {

        Errors IsDataValid(string username, string email, string password,List<UserModel> users);

    }
}