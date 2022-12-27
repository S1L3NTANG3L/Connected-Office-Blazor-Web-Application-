using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataAccessLibrary.Data
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "DefaultConnection";

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }
        //Get All
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var data = await dbConnection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }
        //Get Single
        public async Task<T> LoadSingle<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                T data = await dbConnection.QueryFirstAsync<T>(sql, parameters);
                return data;
            }
        }
        //Delete
        public async Task Delete<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                await dbConnection.ExecuteAsync(sql, parameters);
            }
        }
        //Insert, Update
        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                await dbConnection.ExecuteAsync(sql, parameters);
            }
        }
    }
}