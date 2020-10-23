using ApiLibrary.Models;
using System.Threading.Tasks;

namespace ApiLibrary.Api
{
    public interface IFaceitApi
    {

        Task<FaceitPlayerModel> GetPlayerInformationsByName(string username);
        Task<FaceitCsgoModel> GetStatsByPlayerId(string id);
    }
}