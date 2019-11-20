using System.Collections.Generic;
using System.Data;

namespace Accounting.Repository.Interface
{
    public interface IBaseRepository
    {
        IList<T> Get<T>(string connectionString, string request, IDbConnection connection, IDbTransaction transaction);

        void Save<T>(string connectionString, string storedProcedure, T transactions, IDbConnection connection, IDbTransaction transaction);

        void Update<T>(string _connectionString, string storedProcedure, T request, IDbConnection connection, IDbTransaction transaction);

        void Delete<T>(string _connectionString, string storedProcedure, T request, IDbConnection connection, IDbTransaction transaction);
    }
}
