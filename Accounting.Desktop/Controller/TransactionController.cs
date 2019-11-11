using Accounting.Models.Requests;
using Accounting.Models.Service;
using Accounting.Domain.Services.Utillies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Accounting.Models.Models;
using Accounting.Models.ViewModels;

namespace Accounting.Desktop.Controller
{
    public class TransactionController
    {
        private TransactionService _transactionService;
        private IList<Transaction> _transactions;

        public TransactionController()
        {
            _transactionService = new TransactionService();
        }

        public void GetTransactions()
        {
            _transactions = _transactionService.GetTransactionsByDate(Extensions.GetCurrentMonth());
        }

        public List<TransferViewModel> GetTransfers()
        {
            var res = _transactions.Where(x => x.Description.ToLower().Contains("transfer") || x.Description.ToLower().Contains("trf"))
                  .Select(x => new TransferViewModel
                  {
                      TransactionId = x.TransactionId,
                      Description = x.Description,
                      Amount = x.Amount,
                      TransactionTimestamp = x.TransactionTimestamp,
                      TransactionType = x.TransactionType,
                      AccountType = x.AccountType
                  }).ToList();

            return res;
        }

        public List<TransactionViewModel> GetTransactions(int i)
        {
            var res = _transactions.Where(x => x.AccountTypeId == i)
                 .Select(x => new TransactionViewModel
                 {
                     TransactionId = x.TransactionId,
                     Description = x.Description,
                     Amount = x.Amount,
                     TransactionTimestamp = x.TransactionTimestamp,
                     TransactionType = x.TransactionType,
                     Balance = x.Balance
                 }).ToList();

            return res;
        }

        public List<TransactionViewModel> SearchTransactionsByDate(SearchTransactionByDateRequest transaction)
        {
            var res = _transactionService.SearchTransactionsByDate(transaction)
                 .Select(x => new TransactionViewModel
                 {
                     TransactionId = x.TransactionId,
                     Description = x.Description,
                     Amount = x.Amount,
                     TransactionTimestamp = x.TransactionTimestamp,
                     TransactionType = x.TransactionType,
                     Balance = x.Balance
                 }).ToList();

            return res;
        }

        public List<TransactionSummaryViewModel> GetRecentTransactions()
        {
            var res = _transactions.Select(x => new TransactionSummaryViewModel
            {
                Description = x.Description,
                Amount = x.Amount,
                TransactionTimestamp = x.TransactionTimestamp,
            }).ToList();

            return res;
        }

        public List<TransactionSummaryViewModel> GetTransactionsDebit()
        {
            var res = _transactions.Where(x => x.AccountTypeId == 1 && x.TransactionTypeId == 2)
                .Select(x => new TransactionSummaryViewModel
                {
                    Description = x.Description,
                    Amount = x.Amount,
                    TransactionTimestamp = x.TransactionTimestamp,
                }).ToList();

            return res;
        }

        public List<TransactionSummaryViewModel> GetTransactionsCredit()
        {
            var res = _transactions.Where(x => x.AccountTypeId == 1 && x.TransactionTypeId == 1)
                 .Select(x => new TransactionSummaryViewModel
                 {
                     Description = x.Description,
                     Amount = x.Amount,
                     TransactionTimestamp = x.TransactionTimestamp,
                 }).ToList();

            return res;
        }

        public decimal GetExpenseSubtotal()
        {
            return _transactions.Where(x => x.TransactionTypeId == 2 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();
        }

        public decimal GetIncomeSubtotal()
        {
            return _transactions.Where(x => x.TransactionTypeId == 1 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();
        }

        public UpdateTransactionRequest GetTransactionDetailsFromDataGridView(DataGridView dataGridView)
        {
            if (!dataGridView.SelectedRows.Count.Equals(0))
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];
                return new UpdateTransactionRequest
                {
                    TransactionId = Guid.Parse(selectedRow.Cells[0].Value.ToString()),
                    Description = selectedRow.Cells[1].Value.ToString(),
                    Amount = decimal.Parse(selectedRow.Cells[2].Value.ToString()),
                    Date = DateTime.Parse(selectedRow.Cells[3].Value.ToString())
                };
            }
            return null;
        }

        public void SaveTransaction(SaveTransactionRequest transaction)
        {
            _transactionService.SaveTransaction(transaction);
        }

        public void SaveTransactionStaging(SaveTransactionRequest transaction)
        {
            _transactionService.SaveTransactionStaging(transaction);
        }

        public void UpdateTransaction(UpdateTransactionRequest transaction)
        {
            _transactionService.UpdateTransaction(transaction);
        }

        public void DeleteTransaction(DataGridView dataGridView)
        {
            int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];
            var transaction = new DeleteTransactionRequest { TransactionId = Guid.Parse(selectedRow.Cells[0].Value.ToString()) };
            _transactionService.DeleteTransaction(transaction);
        }
    }
}
