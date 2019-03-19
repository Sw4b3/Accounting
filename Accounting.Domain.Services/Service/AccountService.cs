using Accounting.Domain.Services.Service.Interface;
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
    public class AccountService: IAccountService
    {
        private readonly UnitOfWork uow;

        public AccountService()
        {
            uow = new UnitOfWork();
        }

        public IList<Account> GetAccount()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.AccountRepository.GetAccountRequest();
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }
  
        public void SaveAccount(GetAccountRequest account)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.AccountRepository.SaveAccountRequest(account);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
