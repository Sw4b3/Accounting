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
        public TransactionRepository _TransactionRepository;

        public TransactionController()
        {
            _TransactionRepository = new TransactionRepository();
        }

        public void GetTransactions(DataGridView dataGridView)
        {
            dataGridView.DataSource = _TransactionRepository.GetTransactionsRequest().Select(x => new {x.TransactionId, x.Description, x.Amount, x.Timestamp , x.TransactionType}).ToList();
        }

        public void GetTransactionsByDate(DataGridView dataGridView, TransactionRequest transaction)
        {
            dataGridView.DataSource = _TransactionRepository.GetTransactionsByDateRequest(transaction).Select(x => new { x.TransactionId, x.Description, x.Amount, x.Timestamp, x.TransactionType }).ToList();
        }

        public void GetTransactionsGeneralExpenses(DataGridView dataGridView)
        {
            dataGridView.DataSource = _TransactionRepository.GetTransactionsRequest().Where(x => x.TransactionTypeId == 2 && x.ExpenseId==2).Select(x => new { x.Description, x.Amount, x.Timestamp }).ToList();
        }

        public void GetTransactionsPersonalExpenses(DataGridView dataGridView)
        {
            dataGridView.DataSource = _TransactionRepository.GetTransactionsRequest().Where(x => x.TransactionTypeId == 2 && x.ExpenseId == 3).Select(x => new { x.Description, x.Amount, x.Timestamp}).ToList();
        }

        public void GetTransactionsWithdraw(DataGridView dataGridView)
        {
            dataGridView.DataSource = _TransactionRepository.GetTransactionsRequest().Where(x => x.TransactionTypeId == 1).Select(x => new { x.Description, x.Amount, x.Timestamp}).ToList();
        }

        public double GetTransactionBalance()
        {
            var deposits = _TransactionRepository.GetTransactionsRequest().Where(x => x.TransactionTypeId == 1).Select(x => x.Amount).Sum();
            var withdaws = _TransactionRepository.GetTransactionsRequest().Where(x => x.TransactionTypeId == 2).Select(x => x.Amount).Sum(); 
            return (double)deposits - (double)withdaws;
        }

        public double GetGeneralExpenseSubtotal()
        {
            return (double)_TransactionRepository.GetTransactionsRequest().Where(x => x.TransactionTypeId == 2 && x.ExpenseId==2).Select(x => x.Amount).Sum();
        }

        public double GetPersonalExpenseSubtotal()
        {
           return (double)_TransactionRepository.GetTransactionsRequest().Where(x => x.TransactionTypeId == 2  && x.ExpenseId == 3).Select(x => x.Amount).Sum();
        }

        public double GetIncomeSubtotal()
        {
            return (double)_TransactionRepository.GetTransactionsRequest().Where(x => x.TransactionTypeId == 1).Select(x => x.Amount).Sum();
        }

        public void SaveTransaction(TransactionRequest transaction)
        {
            _TransactionRepository.SaveTransactionsRequest(transaction);
        }
    }
}
