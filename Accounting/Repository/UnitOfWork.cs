using Accounting.Repository.Interface;
using System.Data;
using System.Data.SqlClient;

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
        private IReportRepository _reportRepository;

        public void CreateUnitOfWork()
        {
            _connection = new SqlConnection(DatabaseConnection.connection);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IMappingRepository MappingRepository => _mappingRepository ?? (_mappingRepository = new MappingRepository(_connection, _transaction));

        public ITransactionRepository TransactionRepository => _transactionRepository ?? (_transactionRepository = new TransactionRepository(_connection, _transaction));

        public IAccountRepository AccountRepository => _accountRepository ?? (_accountRepository = new AccountRepository(_connection, _transaction));

        public IAnalyticsRepository AnalyticsRepository => _analyticsRepository ?? (_analyticsRepository = new AnalyticsRepository(_connection, _transaction));


        public IExpenditureRepository ExpenditureRepository => _expenditureRepository ?? (_expenditureRepository = new ExpenditureRepository(_connection, _transaction));

        public IReportRepository ReportRepository => _reportRepository ?? (_reportRepository = new ReportRepository(_connection, _transaction));


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
            _reportRepository = null;
            _mappingRepository = null;
        }
    }
}