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
            return GetAccounts(DatabaseConnection.connection, _connection, _transaction);
        }

        public void SaveAccountRequest(AccountRequest request)
        {
            SaveAccount(DatabaseConnection.connection, request, _connection, _transaction);
        }
    }
}

