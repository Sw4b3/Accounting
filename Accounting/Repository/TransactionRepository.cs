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
        public IList<Transaction> GetTransactionsRequest() {
            return getTransactions(DatabaseConnection.connection, SQLStoredProcedures.getGetTransaction);
        }

        public void SaveTransactionsRequest(TransactionRequest request)
        {
            SaveTransactions(DatabaseConnection.connection, SQLStoredProcedures.saveGetTransaction, request);
        }
    }
}
