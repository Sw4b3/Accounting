using Accounting.Models.Requests;
using Accounting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.Desktop.Controller
{
    public class TransactionController
    {
        private TransactionRepository _TransactionRepository;

        public TransactionController()
        {
            _TransactionRepository = new TransactionRepository();
        }

        public void GetTransactions(DataGridView dataGridView)
        {
            dataGridView.DataSource = _TransactionRepository.GetTransactionsRequest().Select(x => new { x.TransactionId, x.Description, x.Amount, x.TransactionTimestamp, x.TransactionType }).ToList();
        }

        public void GetTransactions(DataGridView dataGridView, int i)
        {
            dataGridView.DataSource = _TransactionRepository.GetTransactionsRequest().Where(x => x.AccountTypetId == i).Select(x => new { x.TransactionId, x.Description, x.Amount, x.TransactionTimestamp, x.TransactionType }).ToList();
        }

        public void GetTransactionsByDate(DataGridView dataGridView, TransactionByDateRequest transaction)
        {
            dataGridView.DataSource = _TransactionRepository.GetTransactionsByDateRequest(transaction).Select(x => new { x.TransactionId, x.Description, x.Amount, x.TransactionTimestamp, x.TransactionType }).ToList();
        }

        public void GetTransactionsGeneralExpenses(DataGridView dataGridView)
        {
            dataGridView.DataSource = _TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth()).Where(x => x.AccountTypetId == 1 && x.TransactionTypeId == 2 && x.ExpenseId == 2).Select(x => new { x.Description, x.Amount, x.TransactionTimestamp }).ToList();
        }

        public void GetTransactionsPersonalExpenses(DataGridView dataGridView)
        {
            dataGridView.DataSource = _TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth()).Where(x => x.AccountTypetId == 1 && x.TransactionTypeId == 2 && x.ExpenseId == 3).Select(x => new { x.Description, x.Amount, x.TransactionTimestamp }).ToList();
        }

        public void GetTransactionsWithdraw(DataGridView dataGridView)
        {
            dataGridView.DataSource = _TransactionRepository.GetTransactionsByDateRequest(getCurrentMonth()).Where(x => x.AccountTypetId == 1 && x.TransactionTypeId == 1).Select(x => new { x.Description, x.Amount, x.TransactionTimestamp }).ToList();
        }

        //public decimal GetTransactionBalance()
        //{
        //    var deposits = _TransactionRepository.GetTransactionsRequest().Where(x => x.TransactionTypeId == 1).Select(x => x.Amount).Sum();
        //    var withdaws = _TransactionRepository.GetTransactionsRequest().Where(x => x.TransactionTypeId == 2).Select(x => x.Amount).Sum();
        //    return deposits - withdaws;
        //}

        public decimal GetTransactionBalance(int accountId)
        {
            var deposits = _TransactionRepository.GetTransactionsRequest().Where(x => x.AccountTypetId == accountId && x.TransactionTypeId == 1).Select(x => x.Amount).Sum();
            var withdaws = _TransactionRepository.GetTransactionsRequest().Where(x => x.AccountTypetId == accountId && x.TransactionTypeId == 2).Select(x => x.Amount).Sum();
            var total = deposits - withdaws;
            return Math.Round(total, 2);
        }

        public decimal GetGeneralExpenseSubtotal()
        {
            return _TransactionRepository.GetTransactionsRequest().Where(x => x.TransactionTypeId == 2 && x.ExpenseId == 2).Select(x => x.Amount).Sum();
        }

        public decimal GetPersonalExpenseSubtotal()
        {
            return _TransactionRepository.GetTransactionsRequest().Where(x => x.TransactionTypeId == 2 && x.ExpenseId == 3).Select(x => x.Amount).Sum();
        }

        public decimal GetIncomeSubtotal()
        {
            return _TransactionRepository.GetTransactionsRequest().Where(x => x.TransactionTypeId == 1).Select(x => x.Amount).Sum();
        }

        public void SaveTransaction(TransactionRequest transaction)
        {
            _TransactionRepository.SaveTransactionsRequest(transaction);
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
