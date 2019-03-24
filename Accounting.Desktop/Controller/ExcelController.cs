using Accounting.Domain.Services.Reports;
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

        public void ImportFromExcel()
        {
            string filename=null;
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

            var transactions = _excelService.ImportFromExcel(filename);
            foreach (var transaction in transactions)
            {
                _transactionService.SaveTransaction(transaction);
            }
        }
    }
}
