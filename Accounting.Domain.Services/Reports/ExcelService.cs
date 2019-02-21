using Accounting.Models.Models;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.Domain.Services.Reports
{
    public class ExcelService
    {
        public void ExportToExcel(List<Transaction> transactions)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    int row = 1;
                    string currentMonth = DateTime.Now.ToString("MMMM");
                    string currentYear = DateTime.Now.Year.ToString();
                    string docName = "Book " + currentMonth + ".xlsx";

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

                    worksheet.Cell(1, 1).Value = currentMonth.ToUpper();
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

                    var income = transactions.Where(x => x.TransactionTypeId == 1 && x.AccountTypeId == 1);

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


                    var generalExpense = transactions.Where(x => x.TransactionTypeId == 2 && x.ExpenseId == 2 && x.AccountTypeId == 1);

                    foreach (var transaction in generalExpense)
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

                    worksheet.Cell(row, 2).Value = generalExpense.Select(x => x.Amount).Sum();
                    worksheet.Cell(row, 2).Style.NumberFormat.Format = "0.00";

                    worksheet.Cell(++row, 1).Value = "Personal Expense";
                    worksheet.Cell(row, 1).Style.Font.Bold = true;
                    worksheet.Cell(row, 1).Style.Font.FontSize = 12;


                    var personalExpense = transactions.Where(x => x.TransactionTypeId == 2 && x.ExpenseId == 3 && x.AccountTypeId == 1);

                    foreach (var transaction in personalExpense)
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

                    worksheet.Cell(row, 2).Value = personalExpense.Select(x => x.Amount).Sum();
                    worksheet.Cell(row, 2).Style.NumberFormat.Format = "0.00";

                    worksheet.Cell(++row, 1).Value = "Total";
                    worksheet.Cell(row, 1).Style.Font.Bold = true;
                    worksheet.Cell(row, 1).Style.Font.FontSize = 12;

                    worksheet.Cell(row, 2).Value = income.Select(x => x.Amount).Sum() - generalExpense.Select(x => x.Amount).Sum() - personalExpense.Select(x => x.Amount).Sum();
                    worksheet.Cell(row, 2).Style.NumberFormat.Format = "0.00";

                 


                    for (int i = 3; i < row; i++)
                    {
                        worksheet.Row(i).Height = 15;
                    }

                    row = 5;

                    var savings = transactions.Where(x => x.AccountTypeId == 2);

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

                    worksheet.Cell(row, 6).Value = savings.Select(x => x.Amount).Sum();
                    worksheet.Cell(row, 6).Style.NumberFormat.Format = "0.00";

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
    }
}
