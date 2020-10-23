using ApiLibrary.Models;
using FaceitFinderUI.Models;
using SqlLibrary.Models;

namespace FaceitFinderUI.Helpers
{
    public interface IMapperHelper
    {
        FaceitUserModel MapToFaceitUserModel(FaceitCsgoModel faceitCsgo);
        UserModel MapToUserModel(UserSqlModel sqlModel);
    }
}