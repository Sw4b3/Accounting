using Accounting.Models.Models;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
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
                    int row = 2;
                    string currentMonth = DateTime.Now.ToString("MMMM");
                    string currentYear = DateTime.Now.Year.ToString();

                    var worksheet = workbook.Worksheets.Add(currentMonth);
                    worksheet.Cell(1, 1).Value = currentMonth;
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontSize = 20;
                    worksheet.Range(1,1,1,5).Row(1).Merge();


                    worksheet.Cell(2, 1).Value = "Description";
                    worksheet.Cell(2,2).Value = "Amount";
                    worksheet.Cell(2,3).Value = "Date";

                    foreach (var transaction in transactions)
                    {
                        worksheet.Cell(++row, 1).Value = transaction.Description;
                        worksheet.Cell(row, 2).Value = transaction.Amount;
                        worksheet.Cell(row, 3).Value = transaction.TransactionTimestamp;
                    }

                    worksheet.Column(1).AdjustToContents();
                    worksheet.Column(2).AdjustToContents();
                    worksheet.Column(3).AdjustToContents();


                    workbook.SaveAs("C:\\Users\\Andrew\\Downloads\\Book "+currentYear+".xlsx");
                    MessageBox.Show("Book Created", "Export", MessageBoxButtons.OK);
                }
            }
            catch (Exception e) {
                MessageBox.Show("Failed to create book", "Export", MessageBoxButtons.OK);
            }
        }
    }
}
