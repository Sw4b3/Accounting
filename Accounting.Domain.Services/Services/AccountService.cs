using Accounting.Domain.Services.Service.Interface;
using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository;
using System;
using System.Collections.Generic;

namespace Accounting.Domain.Services.Service
{
    public class AccountService : IAccountService
    {
        private readonly UnitOfWork uow;

        public AccountService()
        {
            uow = new UnitOfWork();
        }

        public IList<Account> GetAccounts()
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

        public Account GetAccount(GetAccountRequest AccountNo)
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.AccountRepository.GetAccountRequest(AccountNo);
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void SaveAccount(SaveAccountRequest account)
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

        public void UpdateAccount(UpdateAccountRequest request)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.AccountRepository.UpdateAccountRequest(request);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
