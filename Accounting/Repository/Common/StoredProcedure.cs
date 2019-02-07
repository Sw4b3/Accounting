using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository.Common
{
    public static class SQLStoredProcedures
    {
        public const string getGetTransaction= "Call spGetTransactions";
        public const string saveGetTransaction = "Call spSaveTransaction(?Amount,?AcounTypetId,?TransactionTypeId)";
    }
}
