using Accounting.Domain.Services.Service;
using Accounting.Domain.Services.Service.Interface;
using Accounting.Models.Models;
using Accounting.Models.Requests;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Accounting.Domain.Services.Reports
{
    public class ReportHandler
    {
        private readonly IMappingService _mappingService;
        private static string[] currentMonths = DateTimeFormatInfo.CurrentInfo.MonthNames;
        private IList<Mapping> _vauleList;

        public ReportHandler()
        {
            _mappingService = new MappingService();
            _vauleList = _mappingService.GetMappings();
        }

        public void ExportToExcel(List<Transaction> transactions)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    string currentMonth = DateTime.Now.ToString("MMMM");
                    string docName = "Book " + currentMonth + ".xlsx";

                    BuildExcelExport(transactions, workbook, currentMonth);

                    workbook.SaveAs("C:\\Users\\Andrew\\Downloads\\" + docName);
                    MessageBox.Show(docName + " Created", "Export", MessageBoxButtons.OK);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("File is currently open", "Export", MessageBoxButtons.OK);
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to create book", "Export", MessageBoxButtons.OK);
            }
        }

        public void ExportAllToExcel(List<Transaction> transactions)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    string currentYear = DateTime.Now.Year.ToString();
                    string docName = "Book " + currentYear + ".xlsx";

                    foreach (var currentMonth in currentMonths.Where(x => !x.Equals("")))
                    {
                        var res = transactions.Where(x => x.TransactionTimestamp.ToString("MMMM").Equals(currentMonth)).ToList();
                        BuildExcelExport(res, workbook, currentMonth);
                    }
                    workbook.SaveAs("C:\\Users\\Andrew\\Downloads\\" + docName);
                    MessageBox.Show(docName + " Created", "Export", MessageBoxButtons.OK);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("File is currently open", "Export", MessageBoxButtons.OK);
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to create book", "Export", MessageBoxButtons.OK);
            }
        }

        public IList<SaveTransactionRequest> ImportFromExcel(string filename, int accountTypeId)
        {
            IList<SaveTransactionRequest> lines = new List<SaveTransactionRequest>();
            try
            {
                using (var reader = new StreamReader(filename))
                {

                    int rowCount = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        if (7 <= rowCount && !values.Contains(""))
                        {
                            lines.Add(new SaveTransactionRequest
                            {
                                TransactionTimestamp = DateTime.Parse(values[0]),
                                Amount = decimal.Parse(values[1].Replace("-", "")),
                                Balance = decimal.Parse(values[2]),
                                Description = ProcesssString(values[3]),
                                AccountTypeId = accountTypeId,
                                TransactionTypeId = values[1].ToString().Contains("-") ? 2 : 1
                            });
                        }
                        rowCount++;
                    }

                }
            }
            catch (IOException)
            {
                MessageBox.Show("File is currently open", "Import", MessageBoxButtons.OK);
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to Import", "Import", MessageBoxButtons.OK);
            }
            var reverseLines = lines.Reverse();

            return reverseLines.ToList();
        }

        private void BuildExcelExport(List<Transaction> res, XLWorkbook workbook, string currentMonth)
        {
            int row = 1;

            var worksheet = workbook.Worksheets.Add(currentMonth);

            var colA = worksheet.Column(1);
            colA.Width = 25;

            var colB = worksheet.Column(2);
            colB.Width = 10;

            var colC = worksheet.Column(3);
            colC.Width = 17;

            var colE = worksheet.Column(5);
            colE.Width = 25;

            var colF = worksheet.Column(6);
            colF.Width = 10;

            var colG = worksheet.Column(7);
            colG.Width = 17;

            worksheet.Cell(1, 1).Value = currentMonth;
            worksheet.Cell(1, 1).Style.Font.Bold = true;
            worksheet.Cell(1, 1).Style.Font.FontSize = 20;
            worksheet.Range(1, 1, 1, 7).Row(1).Merge();
            worksheet.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Row(1).Height = 25;

            ++row;

            worksheet.Cell(++row, 1).Value = "Easy Account";
            worksheet.Cell(row, 1).Style.Font.Bold = true;
            worksheet.Cell(row, 1).Style.Font.FontSize = 14;
            worksheet.Row(row).Height = 18;

            worksheet.Cell(row, 5).Value = "Savings Account";
            worksheet.Cell(row, 5).Style.Font.Bold = true;
            worksheet.Cell(row, 5).Style.Font.FontSize = 14;
            worksheet.Row(row).Height = 18;

            worksheet.Cell(++row, 1).Value = "Income";
            worksheet.Cell(row, 1).Style.Font.Bold = true;
            worksheet.Cell(row, 1).Style.Font.FontSize = 12;


            worksheet.Cell(++row, 1).Value = "Description";
            worksheet.Cell(row, 1).Style.Font.Bold = true;
            worksheet.Cell(row, 2).Value = "Amount";
            worksheet.Cell(row, 2).Style.Font.Bold = true;
            worksheet.Cell(row, 3).Value = "Date";
            worksheet.Cell(row, 3).Style.Font.Bold = true;

            worksheet.Cell(row, 5).Value = "Description";
            worksheet.Cell(row, 5).Style.Font.Bold = true;
            worksheet.Cell(row, 6).Value = "Amount";
            worksheet.Cell(row, 6).Style.Font.Bold = true;
            worksheet.Cell(row, 7).Value = "Date";
            worksheet.Cell(row, 7).Style.Font.Bold = true;

            var income = res.Where(x => x.TransactionTypeId == 1 && x.AccountTypeId == 1);

            foreach (var transaction in income)
            {
                worksheet.Cell(++row, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                worksheet.Cell(row, 1).Value = transaction.Description;
                worksheet.Cell(row, 2).Value = transaction.Amount;
                worksheet.Cell(row, 2).Style.NumberFormat.Format = "0.00";
                worksheet.Cell(row, 3).Value = transaction.TransactionTimestamp;
            }

            worksheet.Cell(++row, 1).Value = "Subtotal";
            worksheet.Cell(row, 1).Style.Font.Bold = true;
            worksheet.Cell(row, 1).Style.Font.FontSize = 12;
            worksheet.Cell(row, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            worksheet.Cell(row, 2).Value = income.Select(x => x.Amount).Sum();
            worksheet.Cell(row, 2).Style.NumberFormat.Format = "0.00";

            worksheet.Cell(++row, 1).Value = "General Expense";
            worksheet.Cell(row, 1).Style.Font.Bold = true;
            worksheet.Cell(row, 1).Style.Font.FontSize = 12;


            var expense = res.Where(x => x.TransactionTypeId == 2 && x.AccountTypeId == 1);

            foreach (var transaction in expense)
            {
                worksheet.Cell(++row, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                worksheet.Cell(row, 1).Value = transaction.Description;
                worksheet.Cell(row, 2).Value = transaction.Amount;
                worksheet.Cell(row, 2).Style.NumberFormat.Format = "0.00";
                worksheet.Cell(row, 3).Value = transaction.TransactionTimestamp;
            }

            worksheet.Cell(++row, 1).Value = "Subtotal";
            worksheet.Cell(row, 1).Style.Font.Bold = true;
            worksheet.Cell(row, 1).Style.Font.FontSize = 12;
            worksheet.Cell(row, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            worksheet.Cell(row, 2).Value = expense.Select(x => x.Amount).Sum();
            worksheet.Cell(row, 2).Style.NumberFormat.Format = "0.00";

            worksheet.Cell(++row, 1).Value = "Total";
            worksheet.Cell(row, 1).Style.Font.Bold = true;
            worksheet.Cell(row, 1).Style.Font.FontSize = 12;

            worksheet.Cell(row, 2).Value = income.Select(x => x.Amount).Sum() - expense.Select(x => x.Amount).Sum();
            worksheet.Cell(row, 2).Style.NumberFormat.Format = "0.00";

            for (int i = 3; i < row; i++)
            {
                worksheet.Row(i).Height = 15;
            }

            row = 5;

            var savings = res.Where(x => x.AccountTypeId == 2);

            foreach (var transaction in savings)
            {
                worksheet.Cell(++row, 5).Value = transaction.Description;
                worksheet.Cell(row, 6).Value = transaction.Amount;
                worksheet.Cell(row, 6).Style.NumberFormat.Format = "0.00";
                worksheet.Cell(row, 7).Value = transaction.TransactionTimestamp;
            }

            worksheet.Cell(++row, 5).Value = "Total";
            worksheet.Cell(row, 5).Style.Font.Bold = true;
            worksheet.Cell(row, 5).Style.Font.FontSize = 12;

            var credit = res.Where(x => x.AccountTypeId == 2 && x.TransactionTypeId == 1).Select(x => x.Amount).Sum();
            var debit = res.Where(x => x.AccountTypeId == 2 && x.TransactionTypeId == 2).Select(x => x.Amount).Sum();

            worksheet.Cell(row, 6).Value = credit - debit;
            worksheet.Cell(row, 6).Style.NumberFormat.Format = "0.00";
        }

        private string ProcesssString(string value)
        {
            string processedValue = value;
            processedValue = Regex.Replace(processedValue, @"\d", "");
            processedValue = Regex.Replace(processedValue, " *[~%*{}()/:<>?|\"-]+ *", " ");
            processedValue = Regex.Replace(processedValue, "[ ]{2,}", " ");

            //for (int i = 0; i < months.Length; i++)
            //{
            //    processedValue = processedValue.Replace(months[i], "");
            //}

            for (int j = 0; j < _vauleList.Count; j++)
            {
                processedValue = processedValue.Replace(_vauleList[j].ExpectedString, _vauleList[j].ProcessedString);
            }

            processedValue = processedValue.ToUpper().Trim();

            return processedValue;
        }
    }
}
