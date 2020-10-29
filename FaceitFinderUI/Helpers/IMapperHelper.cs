using ApiLibrary.Models;
using FaceitFinderUI.Models;
using SqlLibrary.Models;
using System.Threading.Tasks;

namespace FaceitFinderUI.Helpers
{
    public interface IMapperHelper
    {
        FaceitUserModel MapToFaceitUserModel(FaceitCsgoModel faceitCsgo);
        UserModel MapToUserModel(UserSqlModel sqlModel);
        void MapToSingletonUserModel(UserSqlModel sqlModel, UserModel singleton);
        void MapToSingletonFaceitModel(FaceitCsgoModel sqlModel, FaceitUserModel singleton);
    }
}