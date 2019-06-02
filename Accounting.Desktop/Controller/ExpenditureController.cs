using Accounting.Desktop.Common;
using Accounting.Desktop.Componets;
using Accounting.Desktop.Model;
using Accounting.Domain.Services.Service;
using Accounting.Domain.Services.Service.Interface;
using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Models.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.Desktop.Controller
{
    public class ExpenditureController
    {
        private IExpenditureService _expenditureService;
        private bool isInitialized = false;
        private DataGridViewComboBoxColumn _expenditureRule;

        public ExpenditureController()
        {
            _expenditureService = new ExpenditureService();
            _expenditureRule = new DataGridViewComboBoxColumn();
        }

        public void GetExpenditure(DataGridView dataGridView)
        {
            var res = _expenditureService.GetExpenditureByDateRequest().Where(x => x.ExpenditureRuleId == 0).Select(x => new { x.ExpenditureId, x.TransactionId, x.Description, x.Amount, x.TransactionTimestamp }).ToList();

            IList<ExpenditureRuleItem> list = _expenditureService.GetExpenditureRules().Select(x => new ExpenditureRuleItem { ExpenditureDesc = x.ExpenditureDesc, ExpenditureRuleId = x.ExpenditureRuleId }).ToList();
            _expenditureRule.DataSource = list;
            _expenditureRule.HeaderText = "ExpenditureRuleId";
            _expenditureRule.DisplayMember = "ExpenditureDesc";
            _expenditureRule.ValueMember = "ExpenditureRuleId";
            _expenditureRule.FlatStyle = FlatStyle.Flat;

            dataGridView.DataSource = res;
            if (!isInitialized)
            {
                dataGridView.Columns.Add(_expenditureRule);
                isInitialized = true;
            }
        }

        public void FilterExpenditure(DataGridView dataGridView, ComboBox comboBox)
        {

            if (comboBox.SelectedItem.ToString() == "Unmapped")
            {
                var res = _expenditureService.GetExpenditureByDateRequest().Where(x => x.ExpenditureRuleId == 0)
              .Select(x => new { x.ExpenditureId, x.TransactionId, x.Description, x.Amount, x.TransactionTimestamp }).ToList();
                dataGridView.DataSource = res;
            }
            else
            {
                var res = _expenditureService.GetExpenditureByDateRequest().Select(x => new { x.ExpenditureId, x.TransactionId, x.Description, x.Amount, x.TransactionTimestamp }).ToList();
                dataGridView.DataSource = res;

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

        public void GetExpenditureRules(DataGridView dataGridView)
        {
            dataGridView.DataSource = _expenditureService.GetExpenditureRules().Select(x => new { x.ExpenditureRuleId, x.ExpenditureDesc, x.ExpenditureLimit, x.ShouldDisplay }).ToList();
        }

        public void GetExpenditureOverview(CircularProgressBar.CircularProgressBar bar1, Label rule1, Label current1, Label limit1,
            CircularProgressBar.CircularProgressBar bar2, Label rule2, Label current2, Label limit2,
            CircularProgressBar.CircularProgressBar bar3, Label rule3, Label current3, Label limit3)
        {
            var expenditureOverview = _expenditureService.GetExpenditureOverview().Select(x => new { x.ExpenditureDesc, x.ExpenditureLimit, x.ExpenditureTotal }).ToList();

            if (expenditureOverview.Count >= 1)
            {
                bar1.Maximum = (int)expenditureOverview[0].ExpenditureLimit;
                rule1.Text = expenditureOverview[0].ExpenditureDesc;
            }
            if (expenditureOverview.Count >= 2)
            {
                bar2.Maximum = (int)expenditureOverview[1].ExpenditureLimit;
                rule2.Text = expenditureOverview[1].ExpenditureDesc;
            }
            if (expenditureOverview.Count >= 3)
            {
                bar3.Maximum = (int)expenditureOverview[2].ExpenditureLimit;
                rule3.Text = expenditureOverview[2].ExpenditureDesc;
            }

            if (expenditureOverview.Count >= 1)
            {
                current1.Text = "Current: " + expenditureOverview[0].ExpenditureTotal.ToString();
                limit1.Text = "Limit: " + expenditureOverview[0].ExpenditureLimit.ToString();

                if (expenditureOverview[0].ExpenditureTotal <= expenditureOverview[0].ExpenditureLimit)
                {
                    bar1.Value = (int)expenditureOverview[0].ExpenditureTotal;
                }
                else
                {
                    bar1.Value = (int)expenditureOverview[0].ExpenditureLimit;
                    bar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(147)))), ((int)(((byte)(137)))));
                }
            }
            if (expenditureOverview.Count >= 2)
            {

                current2.Text = "Current: " + expenditureOverview[1].ExpenditureTotal.ToString();
                limit2.Text = "Limit: " + expenditureOverview[1].ExpenditureLimit.ToString();

                if (expenditureOverview[1].ExpenditureTotal <= expenditureOverview[1].ExpenditureLimit)
                {
                    bar2.Value = (int)expenditureOverview[1].ExpenditureTotal;
                }
                else
                {
                    bar2.Value = (int)expenditureOverview[1].ExpenditureLimit;
                    bar2.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(147)))), ((int)(((byte)(137)))));
                }
            }
            if (expenditureOverview.Count >= 3)
            {
                current3.Text = "Current: " + expenditureOverview[2].ExpenditureTotal.ToString();
                limit3.Text = "Limit: " + expenditureOverview[2].ExpenditureLimit.ToString();

                if (expenditureOverview[2].ExpenditureTotal <= expenditureOverview[2].ExpenditureLimit)
                {
                    bar3.Value = (int)expenditureOverview[2].ExpenditureTotal;
                }
                else
                {
                    bar3.Value = (int)expenditureOverview[2].ExpenditureLimit;
                    bar3.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(147)))), ((int)(((byte)(137)))));
                }
            }
        }

        public void PopluateExpenditurePanel(TableLayoutPanel tableLayoutPanel)
        {
            var expenditureOverview = _expenditureService.GetExpenditureRuleOverview().Select(x => new { x.ExpenditureDesc, x.ExpenditureLimit, x.ExpenditureTotal, x.ShouldDisplay }).ToList();
            tableLayoutPanel.Controls.Clear();

            foreach (var item in expenditureOverview)
            {
                if (item.ShouldDisplay)
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
                            BackColor = System.Drawing.Color.WhiteSmoke,
                            ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(227)))), ((int)(((byte)(145))))),
                            Width = 200
                        });
                    }
                    else
                    {
                        tableLayoutPanel.Controls.Add(new CustomProgressBar()
                        {
                            Maximum = (int)item.ExpenditureLimit,
                            Value = (int)item.ExpenditureLimit,
                            BackColor = System.Drawing.Color.WhiteSmoke,
                            ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(147)))), ((int)(((byte)(137))))),
                            Width = 200
                        });
                    }
                }
            }

        }

        public void GetExpenditureBreakdown(DataGridView dataGridView)
        {
            var res = _expenditureService.GetExpenditureRuleOverview().Select(x => new { x.ExpenditureDesc, x.ExpenditureLimit, x.ExpenditureTotal, Difference = x.ExpenditureLimit - x.ExpenditureTotal }).ToList();
            dataGridView.DataSource = res;
        }

        public void ImportExpenditure()
        {
            _expenditureService.ImportExpenditure();
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
