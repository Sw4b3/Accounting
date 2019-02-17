using Accounting.Models.Requests;
using Accounting.Models.Service;
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
        TransactionService _transactionService;

        public TransactionController()
        {
            _transactionService = new TransactionService();
        }

        public void GetTransactions(DataGridView dataGridView)
        {
            dataGridView.DataSource = _transactionService.GetTransactions().Select(x => new { x.TransactionId, x.Description, x.Amount, x.TransactionTimestamp, x.TransactionType }).ToList(); ;
        }

        public void GetTransactionAnalysis(DataGridView dataGridView)
        {
            dataGridView.DataSource = _transactionService.GetTransactionAnalysis();
        }

        public void GetTransactions(DataGridView dataGridView, int i)
        {
            dataGridView.DataSource = _transactionService.GetTransactions().Where(x => x.AccountTypeId == i).Select(x => new { x.TransactionId, x.Description, x.Amount, x.TransactionTimestamp, x.TransactionType }).ToList();
        }

        public void GetTransactionsByDate(DataGridView dataGridView, TransactionByDateRequest transaction)
        {
            dataGridView.DataSource = _transactionService.GetTransactionsByDate(transaction).Select(x => new { x.TransactionId, x.Description, x.Amount, x.TransactionTimestamp, x.TransactionType }).ToList();
        }

        public void GetTransactionsGeneralExpenses(DataGridView dataGridView)
        {
            dataGridView.DataSource = _transactionService.GetTransactions().Where(x => x.AccountTypeId == 1 && x.TransactionTypeId == 2 && x.ExpenseId == 2).Select(x => new { x.Description, x.Amount, x.TransactionTimestamp }).ToList();
        }

        public void GetTransactionsPersonalExpenses(DataGridView dataGridView)
        {
            dataGridView.DataSource = _transactionService.GetTransactions().Where(x => x.AccountTypeId == 1 && x.TransactionTypeId == 2 && x.ExpenseId == 3).Select(x => new { x.Description, x.Amount, x.TransactionTimestamp }).ToList();
        }

        public void GetTransactionsWithdraw(DataGridView dataGridView)
        {
            dataGridView.DataSource = _transactionService.GetTransactions().Where(x => x.AccountTypeId == 1 && x.TransactionTypeId == 1).Select(x => new { x.Description, x.Amount, x.TransactionTimestamp }).ToList();
        }

        public decimal GetTransactionBalance(int accountId)
        {
            return _transactionService.GetTransactionBalanceByAccount(accountId);
        }

        public decimal GetGeneralExpenseSubtotal()
        {
            return _transactionService.GetTransactions().Where(x => x.TransactionTypeId == 2 && x.ExpenseId == 2 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();
        }

        public decimal GetPersonalExpenseSubtotal()
        {
            return _transactionService.GetTransactions().Where(x => x.TransactionTypeId == 2 && x.ExpenseId == 3 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();
        }

        public decimal GetIncomeSubtotal()
        {
            return _transactionService.GetTransactions().Where(x => x.TransactionTypeId == 1 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();
        }

        public TransactionUpdateRequest GetTransactionDetailsFromDataGridView(DataGridView dataGridView)
        {
            if (!dataGridView.SelectedRows.Count.Equals(0))
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];
                return new TransactionUpdateRequest
                {

                    TransactionId = Guid.Parse(selectedRow.Cells[0].Value.ToString()),
                    Description = selectedRow.Cells[1].Value.ToString(),
                    Amount = decimal.Parse(selectedRow.Cells[2].Value.ToString()),
                };
            }
            return null;
        }

        public void SaveTransaction(TransactionRequest transaction)
        {
            _transactionService.SaveTransaction(transaction);
        }

        public void UpdateTransaction(TransactionUpdateRequest transaction)
        {
            _transactionService.UpdateTransaction(transaction);
        }
    }
}
