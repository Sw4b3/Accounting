using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository.Common
{
    public static class SQLStoredProcedures
    {
        public const string getGetTransaction= "spGetTransactions";
        public const string getGetTransactionByDate = "spGetTransactionsByDate";
        public const string searchTransactionByDate = "spSearchTransactionsByDate";
        public const string saveTransaction = "spSaveTransaction";
        public const string updateTransaction = "spUpdateTransaction";
        public const string getGetExpenses = "spGetExpenses";
        public const string getGetAccounts = "spGetAccounts";
        public const string saveAccount = "spSaveAccount";
        public const string getTransactionAnalysis = "spGetTransactionsAnalysis";
    }
}
