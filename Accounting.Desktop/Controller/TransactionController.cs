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

        public void GetTransactions(DataGridView dataGridView1)
        {
            dataGridView1.DataSource = _TransactionRepository.GetTransactionsRequest().Select(x => new { x.TransactionId, x.Amount, x.Timestamp, x.AccountType, x.TransactionType }).ToList();
        }

        public double GetTransactionBalance()
        {

            var deposits = _TransactionRepository.GetTransactionsRequest().Where(x => x.TransactionTypeId == 1).Select(x => x.Amount).Sum();

            var withdaws = _TransactionRepository.GetTransactionsRequest().Where(x => x.TransactionTypeId == 2).Select(x => x.Amount).Sum(); 
            return (double)deposits - (double)withdaws;
        }

        public void SaveTransaction(TransactionRequest transaction)
        {
            _TransactionRepository.SaveTransactionsRequest(transaction);
        }
    }
}
