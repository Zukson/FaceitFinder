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
        void MapToSingletonUserModel(FaceitPlayerModel sqlModel, UserModel singleton);
        void MapToSingletonFaceitModel(FaceitCsgoModel sqlModel, FaceitUserModel singleton);
        void MapToSingletonUserModelSql(UserSqlModel model, UserModel singleton);
        void MapToSingletonSearchedFaceitModel(FaceitCsgoModel faceitModel, SearchedFaceitUserModel singleton);
        void MapToSingletonSearchedUserModel(FaceitPlayerModel model, SearchedUserModel singleton);
    }
}