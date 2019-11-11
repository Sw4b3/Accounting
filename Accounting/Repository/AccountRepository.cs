using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository.Interface
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {

        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public AccountRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public IList<Account> GetAccountRequest()
        {
            return Get<Account>(DatabaseConnection.connection, SQLStoredProcedures.getGetAccounts, _connection, _transaction);
        }

        public Account GetAccountRequest(GetAccountRequest AccountNo)
        {
            var res = GetWithParamater<Account>(DatabaseConnection.connection, SQLStoredProcedures.getGetAccount, AccountNo, _connection, _transaction);
            return res.SingleOrDefault();
        }

        public void SaveAccountRequest(SaveAccountRequest request)
        {
            Save(DatabaseConnection.connection, SQLStoredProcedures.saveAccount, request, _connection, _transaction);
        }

        public void UpdateAccountRequest(UpdateAccountRequest request)
        {
            Update(DatabaseConnection.connection, SQLStoredProcedures.updateAccount, request, _connection, _transaction);
        }
    }
}

