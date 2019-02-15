using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Service
{
    public class TransactionService
    {
        private UnitOfWork uow;

        public TransactionService()
        {
            uow = new UnitOfWork();
        }

        public IList<Transaction> GetTransactions()
        {
            var res = uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
            uow.Commit();
            return res;
        }

        public IList<TransactionAnalysis> GetTransactionAnalysis()
        {
            var res = uow.TransactionRepository.GetTransactionAnalysisRequest();
            uow.Commit();
            return res;
        }

        public IList<Transaction> GetTransactions(int i)
        {
            var res = uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
            uow.Commit();
            return res;
        }

        public IList<Transaction> GetTransactionsByDate(TransactionByDateRequest transaction)
        {
            var res = uow.TransactionRepository.GetTransactionsByDateRequest(transaction);
            uow.Commit();
            return res;
        }

        public IList<Transaction> GetTransactionsGeneralExpenses()
        {
            var res = uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
            uow.Commit();
            return res;
        }

        public IList<Transaction> GetTransactionsPersonalExpenses()
        {
            var res = uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
            uow.Commit();
            return res;
        }

        public IList<Transaction> GetTransactionsWithdraw()
        {
            var res = uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
            return res;
        }

        public decimal GetTransactionBalance(int accountId)
        {
            var deposits = uow.TransactionRepository.GetTransactionsRequest().Where(x => x.AccountTypeId == accountId && x.TransactionTypeId == 1).Select(x => x.Amount).Sum();
            var withdaws = uow.TransactionRepository.GetTransactionsRequest().Where(x => x.AccountTypeId == accountId && x.TransactionTypeId == 2).Select(x => x.Amount).Sum();
            var total = deposits - withdaws;
            return Math.Round(total, 2);
        }

        public IList<Transaction> GetGeneralExpenseSubtotal()
        {
            return uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
        }

        public IList<Transaction> GetPersonalExpenseSubtotal()
        {
            return uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
        }

        public IList<Transaction> GetIncomeSubtotal()
        {
            return uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
        }


        public void SaveTransaction(TransactionRequest transaction)
        {
            uow.TransactionRepository.SaveTransactionsRequest(transaction);
            uow.Commit();
        }

        public void UpdateTransaction(TransactionUpdateRequest transaction)
        {
            uow.TransactionRepository.UpdateTransactionsRequest(transaction);
            uow.Commit();
        }

        public TransactionByDateRequest getCurrentMonth()
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            return new TransactionByDateRequest()
            {
                StartDate = startDate,
                EndDate = endDate
            };
        }
    }
}
