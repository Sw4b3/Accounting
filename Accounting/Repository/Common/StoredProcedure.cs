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
        public const string saveGetTransaction = "spSaveTransaction";
        public const string getGetExpenses = "spGetExpenses";
        public const string getGetAccounts = "spGetAccounts";
    }
}
