using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository.Interface
{
    public class AccountRepository : BaseRepository
    {
        public IList<Account> GetAccountRequest()
        {
            return GetAccounts(DatabaseConnection.connection, SQLStoredProcedures.getGetAccounts);
        }

        public void SaveAccountRequest(AccountRequest request)
        {
            SaveAccount(DatabaseConnection.connection, SQLStoredProcedures.saveAccount, request);
        }
    }
}

