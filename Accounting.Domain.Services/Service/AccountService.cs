using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Services.Service
{
    public class AccountService
    {
        private readonly UnitOfWork uow;

        public AccountService()
        {
            uow = new UnitOfWork();
        }

        public IList<Account> GetAccount()
        {
            var res = uow.AccountRepository.GetAccountRequest();
            uow.Commit();
            return res;
        }
  
        public void SaveAccount(AccountRequest account)
        {
            uow.AccountRepository.SaveAccountRequest(account);
            uow.Commit();
        }
    }
}
