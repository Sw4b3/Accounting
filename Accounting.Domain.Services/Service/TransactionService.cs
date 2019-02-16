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
            uow.CreateUnitOfWork();
            var res = uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
            uow.Commit();
            return res;
        }

        public IList<TransactionAnalysis> GetTransactionAnalysis()
        {
            uow.CreateUnitOfWork();
            var res = uow.TransactionRepository.GetTransactionAnalysisRequest();
            uow.Commit();
            return res;
        }

        public IList<Transaction> GetTransactions(int i)
        {
            uow.CreateUnitOfWork();
            var res = uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
            uow.Commit();
            return res;
        }

        public IList<Transaction> GetTransactionsByDate(TransactionByDateRequest transaction)
        {
            uow.CreateUnitOfWork();
            var res = uow.TransactionRepository.GetTransactionsByDateRequest(transaction);
            uow.Commit();
            return res;
        }

        public IList<Transaction> GetTransactionsGeneralExpenses()
        {
            uow.CreateUnitOfWork();
            var res = uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
            uow.Commit();
            return res;
        }

        public IList<Transaction> GetTransactionsPersonalExpenses()
        {
            uow.CreateUnitOfWork();
            var res = uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
            uow.Commit();
            return res;
        }

        public IList<Transaction> GetTransactionsWithdraw()
        {
            uow.CreateUnitOfWork();
            var res = uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
            uow.Commit();
            return res;
        }

        public decimal GetTransactionBalance(int accountId)
        {
            uow.CreateUnitOfWork();
            var deposits = uow.TransactionRepository.GetTransactionsRequest().Where(x => x.AccountTypeId == accountId && x.TransactionTypeId == 1).Select(x => x.Amount).Sum();
            var withdaws = uow.TransactionRepository.GetTransactionsRequest().Where(x => x.AccountTypeId == accountId && x.TransactionTypeId == 2).Select(x => x.Amount).Sum();
            var total = deposits - withdaws;
            uow.Commit();
            return Math.Round(total, 2);
        }

        public IList<Transaction> GetGeneralExpenseSubtotal()
        {
            uow.CreateUnitOfWork();
            var res = uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
            uow.Commit();
            return res;
        }

        public IList<Transaction> GetPersonalExpenseSubtotal()
        {
            uow.CreateUnitOfWork();
            var res = uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
            uow.Commit();
            return res;
        }

        public IList<Transaction> GetIncomeSubtotal()
        {
            uow.CreateUnitOfWork();
            var res= uow.TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth());
            uow.Commit();
            return res;
        }


        public void SaveTransaction(TransactionRequest transaction)
        {
            uow.CreateUnitOfWork();
            uow.TransactionRepository.SaveTransactionsRequest(transaction);
            uow.Commit();
        }

        public void UpdateTransaction(TransactionUpdateRequest transaction)
        {
            uow.CreateUnitOfWork();
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
