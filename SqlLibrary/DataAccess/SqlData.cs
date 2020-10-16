using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace SqlLibrary.DataAccess
{
    public class SqlData : ISqlData
    {
        public string GetConnectionString(string name)
        {
            string output = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return output;
        }

        public async Task<List<T>> GetAllUsers<T>(string query)
        {

            using (IDbConnection sql = new SQLiteConnection(GetConnectionString("DB")))
            {
                var output = await sql.QueryAsync<T>(query);
                return output.ToList();


            }

        }

        public async Task SaveData<T>(string query, T data, dynamic parameters )
        {
            using (IDbConnection sql = new SQLiteConnection(GetConnectionString("DB")))
            {
                await sql.ExecuteAsync(query, data);


            }

        }
    }
}
