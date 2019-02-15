using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Accounting.Repository.Common
{
    public class DapperRepository
    {
        public static IList<T> ExecuteAsStoredProc<T>(string connectionString, string storedProcedureName)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var res = connection.Query<T>(storedProcedureName, commandType: CommandType.StoredProcedure).ToList();
                return res;
            }
        }

        public static IList<T> ExecuteStoredProc<T>(string connectionString, string storedProcedureName, object request)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var queryParameters = new DynamicParameters(request);

                var res = connection.Query<T>(storedProcedureName, queryParameters, commandType: CommandType.StoredProcedure).ToList();
                return res;
            }
        }

        public static void ExecuteStoredProc(string connectionString, string storedProcedureName, object request)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var queryParameters = new DynamicParameters(request);

                var res = connection.Query(storedProcedureName, queryParameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
