using Accounting.Repository.Interface;
using Accounting.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System;
using Accounting.Models.Requests;
using System.Data;


namespace Accounting.Repository.Common
{
    public class BaseRepository : IBaseRepository
    {
        public IList<T> Get<T>(string connectionString, string request, IDbConnection connection, IDbTransaction transaction)
        {
            var res = DapperRepository.ExecuteStoredProc<T>(connectionString, request, connection, transaction);
            return res;
        }

        public void Save<T>(string connectionString,string storedProcedure, T request, IDbConnection connection, IDbTransaction transaction)
        {
            DapperRepository.ExecuteStoredProc(connectionString, storedProcedure, request, connection, transaction);
        }

        public void Update<T>(string _connectionString, string storedProcedure, T request, IDbConnection connection, IDbTransaction transaction)
        {
            DapperRepository.ExecuteStoredProc(_connectionString, storedProcedure, request, connection, transaction);
        }

        public void Delete<T>(string _connectionString, string storedProcedure, T request, IDbConnection connection, IDbTransaction transaction)
        {
            DapperRepository.ExecuteStoredProc(_connectionString, storedProcedure, request, connection, transaction);
        }
    }
}


