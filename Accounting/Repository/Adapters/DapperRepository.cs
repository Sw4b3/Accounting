using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Accounting.Models.Requests;
using Dapper;

namespace Accounting.Repository.Common
{
    public class DapperRepository
    {
        public static IList<T> ExecuteStoredProc<T>(string connectionString, string storedProcedureName, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var res = connection.Query<T>(storedProcedureName, commandType: CommandType.StoredProcedure, transaction: transaction).ToList();

            return res;
        }

        public static IList<T> ExecuteStoredProc<T>(string connectionString, string storedProcedureName, object request, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var queryParameters = new DynamicParameters(request);

            var res = connection.Query<T>(storedProcedureName, queryParameters, commandType: CommandType.StoredProcedure, transaction: transaction).ToList();

            return res;

        }

        public static void ExecuteStoredProc(string connectionString, string storedProcedureName, object request, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var queryParameters = new DynamicParameters(request);

            var res = connection.Query(storedProcedureName, queryParameters, commandType: CommandType.StoredProcedure, transaction: transaction).ToList();
        }
    }
}
