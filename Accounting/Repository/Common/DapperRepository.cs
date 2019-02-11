using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;

namespace Accounting.Repository.Common
{
    public class DapperRepository
    {
        public IList<T> ExecuteAsStoredProcAsync<T>(string connectionString, string storedProcedureName)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var res = connection.Query<T>(storedProcedureName, commandType: CommandType.StoredProcedure).ToList();
                return res;
            }
        }
    }
}


//var queryParameters = new DynamicParameters();
//queryParameters.Add("@Param0", datatable0.AsTableValuedParameter());
//queryParameters.Add("@Param1", datatable1.AsTableValuedParameter());
//var result = await ExecuteStoredProc("usp_InsertUpdateTest", queryParameters);

//private async Task<Result<int>> ExecuteStoredProc(string sqlStatement, DynamicParameters parameters)
//{
//    try
//    {
//        using (SqlConnection conn = new SqlConnection(connectionString))
//        {
//            await conn.OpenAsync();
//            var affectedRows = await conn.ExecuteAsync(
//                sql: sqlStatement,
//                param: parameters,
//                commandType: CommandType.StoredProcedure);
//            return Result.Ok(affectedRows);
//        }
//    }
//    catch (Exception e)
//    {
//        //do logging
//        return Result.Fail<int>(e.Message);
//    }
//}


//https://stackoverflow.com/questions/21598437/execute-stored-procedure-w-parameters-in-dapper?rq=1
