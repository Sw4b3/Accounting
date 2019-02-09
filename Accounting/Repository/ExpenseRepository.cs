using Accounting.Models.Models;
using Accounting.Repository.Common;
using Accounting.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository
{
    public class ExpenseRepository: BaseRepository
    {
        public IList<Expense> GetExpenseRequest()
        {
            return GetExpenses(DatabaseConnection.connection, SQLStoredProcedures.getGetExpenses);
        }
    }
}
