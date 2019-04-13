using Accounting.Domain.Services.Reports;
using Accounting.Models.Models;
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
    class ExcelController
    {
        TransactionService _transactionService;
        ExcelService _excelService;

        public ExcelController()
        {
            _transactionService = new TransactionService();
            _excelService = new ExcelService();
        }

        public void ExportToTransactions()
        {

            var res = _transactionService.GetTransactions();
            _excelService.ExportToExcel(res.ToList());
        }

        public void ImportFromExcel(int accountType)
        {
           var pendingTransaction = _transactionService.GetTransactions().Where(x => x.TransactionStatus == "Pending").ToList();
            string filename = null;
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"..\\Downloads\\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "csv files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
            }

            var transactions = _excelService.ImportFromExcel(filename, accountType);
            foreach (var transaction in transactions)
            {
                if (pendingTransaction.Count() != 0)
                {
                    foreach (var vaules in pendingTransaction)
                    {
                        if (isMatch(transaction.Description, vaules.Description, transaction.Amount, vaules.Amount, transaction.TransactionTimestamp, vaules.TransactionTimestamp))
                        {
                         
                            _transactionService.UpdateTransaction(new UpdateTransactionRequest
                            {
                                TransactionId = vaules.TransactionId,
                                Description = transaction.Description,
                                Amount = transaction.Amount,
                                Date = DateTime.Now,
                                TransactionStatus = "Processed"
                            });
                            pendingTransaction.Remove(vaules);
                        }
                        else
                        {
                            _transactionService.SaveTransaction(transaction);
                            break;
                        }
                    }
                }
                else
                {
                    _transactionService.SaveTransaction(transaction);
                }
            }
        }

        public bool isMatch(string value1, string value2, decimal value3, decimal value4, DateTime importedDate, DateTime pendingDate)
        {

            if (value1.ToLower().Contains(value2.ToLower()) && value3.ToString("0.00").Equals(value4.ToString("0.00")) && (importedDate.AddDays(-7) >= pendingDate || pendingDate <= importedDate.AddDays(7)))
            {
                return true;
            }
            return false;
        }
    }
}
