using Accounting.Domain.Services.Service.Interface;
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
    public class TransactionService: ITransactionService
    {
        private UnitOfWork uow;

        public TransactionService()
        {
            uow = new UnitOfWork();
        }

        public IList<Transaction> GetTransactions()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.TransactionRepository.GetTransactionsByDateRequest(GetCurrentMonth());
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<TransactionAnalysis> GetTransactionAnalysis()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.TransactionRepository.GetTransactionAnalysisRequest();
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<Transaction> GetTransactionsByDate(TransactionByDateRequest transaction)
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.TransactionRepository.GetTransactionsByDateRequest(transaction);
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void SaveTransaction(TransactionRequest transaction)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.TransactionRepository.SaveTransactionsRequest(transaction);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void UpdateTransaction(TransactionUpdateRequest transaction)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.TransactionRepository.UpdateTransactionsRequest(transaction);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public TransactionByDateRequest GetCurrentMonth()
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

        public decimal GetTransactionBalanceByAccount(int accountId)
        {
            try
            {
                uow.CreateUnitOfWork();
                var transactions = uow.TransactionRepository.GetTransactionsRequest();
                uow.Commit();

                var deposits = transactions.Where(x => x.AccountTypeId == accountId && x.TransactionTypeId == 1).Select(x => x.Amount).Sum();
                var withdaws = transactions.Where(x => x.AccountTypeId == accountId && x.TransactionTypeId == 2).Select(x => x.Amount).Sum();
                var total = deposits - withdaws;

                return Math.Round(total, 2);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
