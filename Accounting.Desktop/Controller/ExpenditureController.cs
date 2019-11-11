using Accounting.Desktop.Componets;
using Accounting.Desktop.Model;
using Accounting.Domain.Services.Service;
using Accounting.Domain.Services.Service.Interface;
using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Accounting.Desktop.Controller
{
    public class ExpenditureController
    {
        private IExpenditureService _expenditureService;

        private Color SystemGreen = Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(227)))), ((int)(((byte)(145)))));
        private Color SystemRed = Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(147)))), ((int)(((byte)(137)))));

        public ExpenditureController()
        {
            _expenditureService = new ExpenditureService();

        }

        public List<ExpenditureViewModel> GetExpenditure(DateTime date)
        {
            var startDate = new DateTime(date.Year, date.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var res = _expenditureService.GetExpenditureByDateRequest(new DateRequest()
            {
                StartDate = startDate,
                EndDate = endDate
            })
            .Where(x => x.ExpenditureRuleId == 0)
            .Select(x => new ExpenditureViewModel
            {
                ExpenditureId = x.ExpenditureId,
                TransactionId = x.TransactionId,
                Description = x.Description,
                Amount = x.Amount,
                TransactionTimestamp = x.TransactionTimestamp,

            }).ToList();

            return res;
        }

        public List<ExpenditureRuleItem> GetExpenditureRulesList()
        {
            var res = _expenditureService.GetExpenditureRules()
                .Select(x => new ExpenditureRuleItem { ExpenditureDesc = x.ExpenditureDesc, ExpenditureRuleId = x.ExpenditureRuleId }).ToList();

            return res;
        }

        public List<ExpenditureBreakdown> FilterExpenditureBreakdownByDate(DateTime date)
        {
            var startDate = new DateTime(date.Year, date.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var res = _expenditureService.GetExpenditureRuleOverview(new DateRequest()
            {
                StartDate = startDate,
                EndDate = endDate
            }).Select(x => new ExpenditureBreakdown
            {
                ExpenditureDesc = x.ExpenditureDesc,
                ExpenditureLimit = x.ExpenditureLimit,
                ExpenditureTotal = x.ExpenditureTotal,
                Difference = x.ExpenditureLimit - x.ExpenditureTotal
            }).ToList();

            return res;
        }

        public List<ExpenditureViewModel> FilterExpenditure(ComboBox comboBox, DateTime date)
        {

            if (comboBox.SelectedItem.ToString() == "Unmapped")
            {
                var startDate = new DateTime(date.Year, date.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                var res = _expenditureService.GetExpenditureByDateRequest(new DateRequest()
                {
                    StartDate = startDate,
                    EndDate = endDate
                }).Where(x => x.ExpenditureRuleId == 0)
               .Select(x => new ExpenditureViewModel
               {
                   ExpenditureId = x.ExpenditureId,
                   TransactionId = x.TransactionId,
                   Description = x.Description,
                   Amount = x.Amount,
                   TransactionTimestamp = x.TransactionTimestamp,

               }).ToList();

                return res;
            }
            else
            {
                var startDate = new DateTime(date.Year, date.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                var res = _expenditureService.GetExpenditureByDateRequest(new DateRequest()
                {
                    StartDate = startDate,
                    EndDate = endDate
                }).Where(x => x.ExpenditureRuleId != 0)
                .Select(x => new ExpenditureViewModel
                {
                    ExpenditureId = x.ExpenditureId,
                    TransactionId = x.TransactionId,
                    Description = x.Description,
                    Amount = x.Amount,
                    TransactionTimestamp = x.TransactionTimestamp,

                }).ToList();

                return res;
            }

        }

        public void GetExpenditureTypes(ComboBox comboBox)
        {
            var expenditureTypes = _expenditureService.GetExpenditureTypes().Select(x => new ExpenditureTypeItem { ExpenditureTypeId = x.ExpenditureTypeId, ExpenditureDesc = x.ExpenditureDesc }).ToList();
            comboBox.DataSource = expenditureTypes.ToList();
        }

        public int GetExpenditureTypeId(ComboBox comboBox)
        {
            return ((ExpenditureTypeItem)comboBox.SelectedItem).ExpenditureTypeId;
        }

        public List<ExpenditureRule> GetExpenditureRules()
        {
            var res = _expenditureService.GetExpenditureRules().ToList();
            return res;
        }

        public void GetExpenditureOverview(CircularProgressBar.CircularProgressBar bar1, Label rule1, Label current1, Label limit1,
            CircularProgressBar.CircularProgressBar bar2, Label rule2, Label current2, Label limit2,
            CircularProgressBar.CircularProgressBar bar3, Label rule3, Label current3, Label limit3)
        {
            var expenditureOverview = _expenditureService.GetExpenditureOverview();

            if (expenditureOverview.Count != 0)
            {
                var debitExpense = expenditureOverview.FirstOrDefault(eo => eo.ExpenditureDesc == "Debit Expense");

                bar1.Maximum = (int)debitExpense.ExpenditureLimit;
                rule1.Text = debitExpense.ExpenditureDesc;

                current1.Text = "Current: " + debitExpense.ExpenditureTotal.ToString();
                limit1.Text = "Limit: " + debitExpense.ExpenditureLimit.ToString();

                if (debitExpense.ExpenditureTotal <= debitExpense.ExpenditureLimit)
                {
                    bar1.Value = (int)debitExpense.ExpenditureTotal;
                }
                else
                {
                    bar1.Value = (int)debitExpense.ExpenditureLimit;
                    bar1.ProgressColor = SystemRed;
                }

                var livingExpense = expenditureOverview.FirstOrDefault(eo => eo.ExpenditureDesc == "Living Expense");

                bar2.Maximum = (int)livingExpense.ExpenditureLimit;
                rule2.Text = livingExpense.ExpenditureDesc;

                current2.Text = "Current: " + livingExpense.ExpenditureTotal.ToString();
                limit2.Text = "Limit: " + livingExpense.ExpenditureLimit.ToString();

                if (livingExpense.ExpenditureTotal <= livingExpense.ExpenditureLimit)
                {
                    bar2.Value = (int)livingExpense.ExpenditureTotal;
                }
                else
                {
                    bar2.Value = (int)livingExpense.ExpenditureLimit;
                    bar2.ProgressColor = SystemRed;
                }

                var otherExpense = expenditureOverview.FirstOrDefault(eo => eo.ExpenditureDesc == "Other Expense");

                bar3.Maximum = (int)otherExpense.ExpenditureLimit;
                rule3.Text = otherExpense.ExpenditureDesc;

                current3.Text = "Current: " + otherExpense.ExpenditureTotal.ToString();
                limit3.Text = "Limit: " + otherExpense.ExpenditureLimit.ToString();

                if (otherExpense.ExpenditureTotal <= otherExpense.ExpenditureLimit)
                {
                    bar3.Value = (int)otherExpense.ExpenditureTotal;
                }
                else
                {
                    bar3.Value = (int)otherExpense.ExpenditureLimit;
                    bar3.ProgressColor = SystemRed;
                }
            }
        }

        public void PopluateExpenditurePanel(TableLayoutPanel tableLayoutPanel)
        {
            var expenditureOverview = _expenditureService.GetExpenditureRuleOverview().Select(x => new { x.ExpenditureDesc, x.ExpenditureLimit, x.ExpenditureTotal, x.ShouldDisplay }).ToList();
            tableLayoutPanel.Controls.Clear();

            foreach (var item in expenditureOverview)
            {
                if (item.ShouldDisplay && item.ExpenditureLimit != 0)
                {
                    //tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                    tableLayoutPanel.Controls.Add(new Label()
                    {
                        Text = item.ExpenditureDesc.ToString()
                    });

                    if (item.ExpenditureTotal <= item.ExpenditureLimit)
                    {
                        tableLayoutPanel.Controls.Add(new CustomProgressBar()
                        {
                            Maximum = (int)item.ExpenditureLimit,
                            Value = (int)item.ExpenditureTotal,
                            BackColor = Color.WhiteSmoke,
                            ForeColor = SystemGreen,
                            Width = 200
                        });
                    }
                    else
                    {
                        tableLayoutPanel.Controls.Add(new CustomProgressBar()
                        {
                            Maximum = (int)item.ExpenditureLimit,
                            Value = (int)item.ExpenditureLimit,
                            BackColor = Color.WhiteSmoke,
                            ForeColor = SystemRed,
                            Width = 200
                        });
                    }
                }
            }

        }

        public List<ExpenditureBreakdown> GetExpenditureBreakdown()
        {
            var res = _expenditureService.GetExpenditureRuleOverview().
                Select(x => new ExpenditureBreakdown
                {
                    ExpenditureDesc = x.ExpenditureDesc,
                    ExpenditureLimit = x.ExpenditureLimit,
                    ExpenditureTotal = x.ExpenditureTotal,
                    Difference = x.ExpenditureLimit - x.ExpenditureTotal
                }).ToList();
            return res;
        }

        public void ImportExpenditure(DateTime date)
        {
            var startDate = new DateTime(date.Year, date.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            _expenditureService.ImportExpenditure(new DateRequest()
            {
                StartDate = startDate,
                EndDate = endDate
            });
        }


        public void SaveExpenditureRules(SaveExpenditureTypeRequest expenditureRequest)
        {
            _expenditureService.SaveExpenditureRule(expenditureRequest);
        }

        public void UpdateExpenditure(UpdateExpenditureRequest expenditureRequest)
        {
            _expenditureService.UpdateExpenditure(expenditureRequest);
        }

        public void UpdateExpenditureRule(UpdateExpenditureRuleRequest expenditureRequest)
        {
            _expenditureService.UpdateExpenditureRule(expenditureRequest);
        }

        public void DeleteExpenditureRule(int expenditureRuleId)
        {
            _expenditureService.DeleteExpenditureRule(new DeleteExpenditureRuleRequest
            {
                ExpenditureRuleId = expenditureRuleId,
                IsArchived = true,
                ArchivedDate = DateTime.Now
            });
        }

        public UpdateExpenditureRuleRequest GetExpenditureSettingsDetailsFromDataGridView(DataGridView dataGridView)
        {
            if (!dataGridView.SelectedRows.Count.Equals(0))
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];
                return new UpdateExpenditureRuleRequest
                {
                    ExpenditureRuleId = int.Parse(selectedRow.Cells[0].Value.ToString()),
                    ExpenditureDesc = selectedRow.Cells[1].Value.ToString(),
                    ExpenditureLimit = decimal.Parse(selectedRow.Cells[2].Value.ToString()),
                    ShouldDisplay = bool.Parse(selectedRow.Cells[3].Value.ToString()),
                };
            }
            return null;
        }

        public void GetExpenditureDetailsFromDataGridView(DataGridView dataGridView)
        {
            if (!dataGridView.SelectedRows.Count.Equals(0))
            {
                foreach (DataGridViewRow rows in dataGridView.Rows)
                {
                    if (rows.Cells[0].Value != null)
                    {
                        UpdateExpenditure(new UpdateExpenditureRequest
                        {
                            ExpenditureId = Guid.Parse(rows.Cells[1].Value.ToString()),
                            ExpenditureRuleId = int.Parse(rows.Cells[0].Value.ToString())
                        });
                    }

                }
            }

        }
    }
}
