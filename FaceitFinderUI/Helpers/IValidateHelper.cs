using FaceitFinderUI.Models;
using SqlLibrary.Models;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace FaceitFinderUI.Helpers
{
    public interface IValidateHelper
    {

        Errors IsDataValid(string username, string email, string password,List<UserModel> users);
        Task<UserSqlModel> CheckLoginData(string email, string password);

    }
}