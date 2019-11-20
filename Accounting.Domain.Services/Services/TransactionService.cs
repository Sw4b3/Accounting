using Accounting.Domain.Services.Service.Interface;
using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository;
using System;
using System.Collections.Generic;

namespace Accounting.Models.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly UnitOfWork uow;

        public TransactionService()
        {
            uow = new UnitOfWork();
        }

        public IList<Transaction> GetTransactionsByDate(DateRequest request)
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.TransactionRepository.GetTransactionsByDateRequest(request);
                uow.Commit();
                return res;
            }
            catch (Exception)
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
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveTransaction(SaveTransactionRequest transaction)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.TransactionRepository.SaveTransactionRequest(transaction);
                uow.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveTransactionStaging(SaveTransactionRequest transaction)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.TransactionRepository.SaveTransactionStagingRequest(transaction);
                uow.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateTransaction(UpdateTransactionRequest transaction)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.TransactionRepository.UpdateTransactionRequest(transaction);
                uow.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteTransaction(DeleteTransactionRequest transaction)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.TransactionRepository.DeleteTransactionStagingRequest(transaction);
                uow.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
