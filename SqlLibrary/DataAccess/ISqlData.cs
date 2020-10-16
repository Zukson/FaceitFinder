using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlLibrary.DataAccess
{
    public interface ISqlData
    {
        Task<List<T>> GetAllUsers<T>(string query);
        string GetConnectionString(string name);
        Task SaveData<T>(string query, T data);
    }
}