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

        public IList<TransactionAnalysisByDay> GetTransactionAnalysisByDay()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.TransactionRepository.GetTransactionAnalysisByDayRequest();
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<Transaction> GetTransactionsByDate(GetTransactionByDateRequest transaction)
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

        public IList<Transaction> SearchTransactionsByDate(SearchTransactionByDateRequest transaction)
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.TransactionRepository.SearchTransactionsByDateRequest(transaction);
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void SaveTransaction(GetTransactionRequest transaction)
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

        public void UpdateTransaction(UpdateTransactionRequest transaction)
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

        public GetTransactionByDateRequest GetCurrentMonth()
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            return new GetTransactionByDateRequest()
            {
                StartDate = startDate,
                EndDate = endDate
            };
        }

    }
}
