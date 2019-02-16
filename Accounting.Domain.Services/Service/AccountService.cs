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
            uow.CreateUnitOfWork();
            var res = uow.AccountRepository.GetAccountRequest();

            return res;
        }
  
        public void SaveAccount(AccountRequest account)
        {
            uow.CreateUnitOfWork();
            uow.AccountRepository.SaveAccountRequest(account);
 
        }
    }
}
