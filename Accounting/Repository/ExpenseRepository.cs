using Accounting.Models.Models;
using Accounting.Repository.Common;
using Accounting.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository
{
    public class ExpenseRepository: BaseRepository, IExpenseRepository
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public ExpenseRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public IList<Expense> GetExpenseRequest()
        {
            return GetExpenses(DatabaseConnection.connection, _connection, _transaction);
        }
    }
}
