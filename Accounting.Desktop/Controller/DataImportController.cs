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
using System.Windows.Forms;

namespace Accounting.Desktop.Controller
{
    public class DataImportController
    {
        private readonly AccountService _accountService;
        private readonly ITransactionService _transactionService;
        private readonly IReportService _reportService;
        private readonly ReportHandler _reportHanlder;
        private readonly IMappingService _mappingService;

        public DataImportController()
        {
            _accountService = new AccountService();
            _transactionService = new TransactionService();
            _reportService = new ReportService();
            _reportHanlder = new ReportHandler();
            _mappingService = new MappingService();
        }

        public List<Mapping> GetMappings()
        {
            var res = _mappingService.GetMappings().ToList();
            return res;
        }

        public void SaveMapping(SaveMappingRequest request)
        {
            _mappingService.SaveMapping(request);
        }

        public void DeleteMapping(int mappingId)
        {
            _mappingService.DeleteMapping(new DeleteMappingRequest { MappingId = mappingId });
        }

        public List<ProssedImportFiles> GetImports()
        {
            var res = _reportService.GetImportFile().ToList();
            return res;
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


                var account = _accountService.GetAccount(new GetAccountRequest
                {
                    AccountNo = accountNoString
                });

                if (account != null)
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
                        new ImportDialog(mainForm, filename).Show();
                    }
                }
                else
                {
                    new ImportDialog(mainForm, filename).Show();
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
                            if (Extensions.IsMatch(transaction.Description, vaules.Description, transaction.Amount, vaules.Amount, transaction.TransactionTimestamp, vaules.TransactionTimestamp))
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
    }
}
