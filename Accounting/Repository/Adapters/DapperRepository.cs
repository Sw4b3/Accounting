using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Accounting.Repository.Common
{
    public class DapperRepository
    {
        public IList<T> ExecuteAsStoredProc<T>(string connectionString, string storedProcedureName)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var res = connection.Query<T>(storedProcedureName, commandType: CommandType.StoredProcedure).ToList();
                return res;
            }
        }

        public IList<T> ExecuteStoredProc<T>(string connectionString, string storedProcedureName, object request)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var queryParameters = new DynamicParameters(request);

                var res = connection.Query<T>(storedProcedureName, queryParameters, commandType: CommandType.StoredProcedure).ToList();
                return res;
            }
        }

        public void ExecuteStoredProc(string connectionString, string storedProcedureName, object request)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var queryParameters = new DynamicParameters(request);

                var res = connection.Query(storedProcedureName, queryParameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}



////https://stackoverflow.com/questions/21598437/execute-stored-procedure-w-parameters-in-dapper?rq=1
