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
        private IMappingRepository _mappingRepository;
        private ITransactionRepository _transactionRepository;
        private IAccountRepository _accountRepository;
        private IAnalyticsRepository _analyticsRepository;
        private IExpenditureRepository _expenditureRepository;

        public void CreateUnitOfWork() {
            _connection = new SqlConnection(DatabaseConnection.connection);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IMappingRepository MappingRepository
        {
            get
            {
                return _mappingRepository ?? (_mappingRepository = new MappingRepository(_connection, _transaction));
            }
        }

        public ITransactionRepository TransactionRepository
        {
            get
            {
                return _transactionRepository ?? (_transactionRepository = new TransactionRepository(_connection, _transaction));
            }
        }

        public IAccountRepository AccountRepository
        {
            get
            {
                return _accountRepository ?? (_accountRepository = new AccountRepository(_connection, _transaction));
            }
        }

        public IAnalyticsRepository AnalyticsRepository
        {
            get
            {
                return _analyticsRepository ?? (_analyticsRepository = new AnalyticsRepository(_connection, _transaction));
            }
        }


        public IExpenditureRepository ExpenditureRepository
        {
            get
            {
                return _expenditureRepository ?? (_expenditureRepository = new ExpenditureRepository(_connection, _transaction));
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
                ResetRepositories();
                Dispose();
            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }

        private void ResetRepositories()
        {
            _transactionRepository = null;
            _accountRepository = null;
            _analyticsRepository = null;
            _expenditureRepository = null;
        }
    }
}