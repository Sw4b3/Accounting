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
            dataGridView1.DataSource = _TransactionRepository.GetTransactionsRequest().Select(x => new { x.TransactionId, x.Amount, x.Timestamp, x.AcounTypetId, x.TransactionTypeId }).ToList();
        }

        public void SaveTransaction(TransactionRequest transaction)
        {
            _TransactionRepository.SaveTransactionsRequest(transaction);
        }
    }
}
