namespace DataAccessLibrary.Data
{
    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task<T> LoadSingle<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
        Task Delete<T>(string sql, T parameters);
    }
}