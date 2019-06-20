using Accounting.Domain.Services.Reports;
using Accounting.Domain.Services.Service.Interface;
using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Models.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.Desktop.Controller
{
    class ReportController
    {
        ITransactionService _transactionService;
        ReportService _reportService;

        public ReportController()
        {
            _transactionService = new TransactionService();
            _reportService = new ReportService();
        }

        public void ExportToTransactions()
        {

            var res = _transactionService.GetTransactionsByDate();
            _reportService.ExportToExcel(res.ToList());
        }

        public void ImportFromExcel(int accountType)
        {
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

            var importTransactionList = _reportService.ImportFromExcel(filename, accountType).ToList();
            var pendingTransactionList = _transactionService.GetTransactionsByDate().Where(x => x.Balance == "Pending").ToList();

            foreach (var transaction in importTransactionList.ToList())
            {
                if (pendingTransactionList.Count() != 0)
                {
                    foreach (var vaules in pendingTransactionList.ToList())
                    {
                        if (isMatch(transaction.Description, vaules.Description, transaction.Amount, vaules.Amount, transaction.TransactionTimestamp, vaules.TransactionTimestamp))
                        {
                            _transactionService.DeleteTransaction(new DeleteTransactionRequest { TransactionId = vaules.TransactionId });
                            pendingTransactionList.Remove(vaules);
                            importTransactionList.Remove(transaction);
                            break;
                        }
                    }
                }

                _transactionService.SaveTransaction(transaction);

            }
            _transactionService.SaveImportFile(new SaveImportFileRequest { Filename = Path.GetFileName(filename), RowCount = importTransactionList.Count });
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
