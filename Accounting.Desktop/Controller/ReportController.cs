using Accounting.Desktop.View.Dialog;
using Accounting.Domain.Services.Reports;
using Accounting.Domain.Services.Service;
using Accounting.Domain.Services.Service.Interface;
using Accounting.Domain.Services.Utillies;
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
        private TransactionController _transactionController;
        private AccountController _accountController;
        private ITransactionService _transactionService;
        private IReportService _reportService;
        private ReportHandler _reportHanlder;

        public ReportController()
        {
            _transactionController = new TransactionController();
            _accountController = new AccountController();
            _transactionService = new TransactionService();
            _reportService = new ReportService();
            _reportHanlder = new ReportHandler();
        }

        public void GetImport(DataGridView dataGridView)
        {
            dataGridView.DataSource = _reportService.GetImportFile();
        }

        public void RollbackImport(Guid fileId)
        {
            _reportService.RollbackImport(new ImportFileRequest { FileId = fileId });
        }

        public void DeleteImport(Guid fileId)
        {
            _reportService.DeleteImport(new ImportFileRequest { FileId = fileId });
        }

        public void CompleteImport(Guid fileId)
        {
            _reportService.CompleteImport(new ImportFileRequest { FileId = fileId });
        }

        public void ExportToTransactions()
        {

            var res = _transactionService.GetTransactionsByDate(Extensions.GetCurrentMonth());
            _reportHanlder.ExportToExcel(res.ToList());
        }

        public void ExportToAllTransactions()
        {

            var res = _transactionService.GetTransactionsByDate(Extensions.GetMonths());
            _reportHanlder.ExportAllToExcel(res.ToList());
        }

        public void OpenFileDialog(MainApplication mainForm)
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

                var accountNoString = Path.GetFileName(filename).Split(' ')[0];

                //var isSuccessful = Int64.TryParse(accountNoString, out accountNo);


                var account = _accountController.GetAccount(new GetAccountRequest
                {
                    AccountNo = accountNoString
                });

                if (!string.IsNullOrEmpty(account.AccountNo))
                {

                    if (account != null)
                    {
                        MessageBox.Show("Account Type detected as " + account.AccountType, "Account Detection", MessageBoxButtons.OK);
                        ImportFromExcel(filename, account.AccountId);
                        mainForm.PopulateTransactionTables();
                        mainForm.FilterTransactionByAccount();
                    }
                    else
                    {
                        new ImportDialog(_transactionController, mainForm, filename).Show();
                    }
                }
                else
                {
                    new ImportDialog(_transactionController, mainForm, filename).Show();
                }
            }
        }

        public void ImportFromExcel(string filename, int accountType)
        {
            var importTransactionList = _reportHanlder.ImportFromExcel(filename, accountType).ToList();
            var pendingTransactionList = _transactionService.GetTransactionsByDate(Extensions.GetCurrentMonth()).Where(x => x.Balance == "Pending").ToList();

            _reportService.SaveImportFile(new SaveImportFileRequest { Filename = Path.GetFileName(filename), RowCount = importTransactionList.Count, AccountTypeId = accountType });

            if (!importTransactionList.Count().Equals(0))
            {
                foreach (var transaction in importTransactionList.ToList())
                {
                    if (pendingTransactionList.Count() != 0)
                    {
                        foreach (var vaules in pendingTransactionList.ToList())
                        {
                            if (IsMatch(transaction.Description, vaules.Description, transaction.Amount, vaules.Amount, transaction.TransactionTimestamp, vaules.TransactionTimestamp))
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
                MessageBox.Show("Data Imported", "Import", MessageBoxButtons.OK);
            }
        }

        public bool IsMatch(string value1, string value2, decimal value3, decimal value4, DateTime importedDate, DateTime pendingDate)
        {

            if (value1.ToLower().Contains(value2.ToLower()) && value3.ToString("0.00").Equals(value4.ToString("0.00")) && (importedDate.AddDays(-4) >= pendingDate || pendingDate <= importedDate.AddDays(4)))
            {
                return true;
            }
            return false;
        }
    }
}
