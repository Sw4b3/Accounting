using Accounting.Repository.Common;
using Accounting.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository
{
    public class UnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private ITransactionRepository _transactionRepository;
        private IAccountRepository _accountRepository;
        private IExpenseRepository _expenseRepository;

        public UnitOfWork()
        {
            _connection = new SqlConnection(DatabaseConnection.connection);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }


        public ITransactionRepository TransactionRepository
        {
            get
            {
                return _transactionRepository ?? (_transactionRepository = new TransactionRepository());
            }
        }

        public IAccountRepository AccountRepository
        {
            get
            {
                return _accountRepository ?? (_accountRepository = new AccountRepository());
            }
        }


        public IExpenseRepository ExpenseRepository
        {
            get
            {
                return _expenseRepository ?? (_expenseRepository = new ExpenseRepository());
            }
        }


        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }



        private void resetRepositories()
        {
            _transactionRepository = null;
        }







    }

}