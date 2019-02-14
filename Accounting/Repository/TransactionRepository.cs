using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository.Common;
using Accounting.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository
{
    public class TransactionRepository: BaseRepository, ITransactionRepository
    {
        public IList<Transaction> GetTransactionsRequest()
        {
            return GetTransactions(DatabaseConnection.connection, SQLStoredProcedures.getGetTransaction);
        }

        public IList<Transaction> GetTransactionsByDateRequest(TransactionByDateRequest request)
        {
            return GetTransactionsByDate(DatabaseConnection.connection, SQLStoredProcedures.getGetTransactionByDate, request);
        }

        public void SaveTransactionsRequest(TransactionRequest request)
        {
            SaveTransactions(DatabaseConnection.connection, SQLStoredProcedures.saveTransaction, request);
        }

        public void UpdateTransactionsRequest(TransactionUpdateRequest request)
        {
            UpdateTransactions(DatabaseConnection.connection, SQLStoredProcedures.updateTransaction, request);
        }
    }
}
