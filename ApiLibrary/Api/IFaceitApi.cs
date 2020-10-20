using System.Threading.Tasks;

namespace ApiLibrary.Api
{
    public interface IFaceitApi
    {
        int MyProperty { get; set; }
        Task<string> GetPlayerIdByName(string username);
        Task<string> GetStatsByPlayerId(string id);
    }
}