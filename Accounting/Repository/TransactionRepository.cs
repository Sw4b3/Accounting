using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository
{
    public class TransactionRepository: BaseRepository
    {
        //public IList<Transaction> GetTransactionsRequest() {
        //    return GetTransactions(DatabaseConnection.connection, SQLStoredProcedures.getGetTransaction);
        //}

        public IList<Transaction> GetTransactionsRequest()
        {
            DapperRepository _dapperRepository = new DapperRepository();
            var res= _dapperRepository.ExecuteAsStoredProcAsync<Transaction>(DatabaseConnection.connection, SQLStoredProcedures.getGetTransaction);
            return res;
        }

        public IList<Transaction> GetTransactionsByDateRequest(TransactionRequest request)
        {
            return GetTransactionsByDate(DatabaseConnection.connection, SQLStoredProcedures.getGetTransactionByDate, request);
        }

        public void SaveTransactionsRequest(TransactionRequest request)
        {
            SaveTransactions(DatabaseConnection.connection, SQLStoredProcedures.saveGetTransaction, request);
        }
    }
}
