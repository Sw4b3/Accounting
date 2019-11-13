using Accounting.Desktop.Model;
using Accounting.Domain.Services.Service;
using Accounting.Models.Models;
using Accounting.Models.Requests;
using System.Collections.Generic;
using System.Linq;


namespace Accounting.Desktop.Controller
{
    public class AccountController
    {
        private readonly AccountService _accountService;

        public AccountController()
        {
            _accountService = new AccountService();
        }

        public List<AccountViewModel> GetAccounts()
        {
            var res = _accountService.GetAccounts().Select(x => new AccountViewModel
            {
                AccountId = x.AccountId,
                AccountNo = x.AccountNo,
                AccountType = x.AccountType,
                Status = x.Status,
                CurrentBalance = x.CurrentBalance,
                AvailableBalance = x.AvailableBalance
            }).ToList();
            return res;
        }

        public Account GetAccount(GetAccountRequest getAccountRequest)
        {
            return _accountService.GetAccount(getAccountRequest);
        }

        public List<AccountItem> GetAccountsItem()
        {
            var res = _accountService.GetAccounts().Select(x => new AccountItem { AccountId = x.AccountId, AccountType = x.AccountType }).ToList();
            return res;
        }

        public string GetAccountBalance(int accountId)
        {
            return _accountService.GetAccounts().FirstOrDefault(x => x.AccountId == accountId).CurrentBalance.ToString();
        }

        public string GetAccountAvaliableBalance(int accountId)
        {
            return _accountService.GetAccounts().FirstOrDefault(x => x.AccountId == accountId).AvailableBalance.ToString();
        }


        public void SaveAccount(SaveAccountRequest account)
        {
            _accountService.SaveAccount(account);
        }

        public void UpdateAccount(UpdateAccountRequest request)
        {
            _accountService.UpdateAccount(request);
        }
    }
}
