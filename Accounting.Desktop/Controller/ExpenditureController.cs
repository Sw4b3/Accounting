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
        DataGridViewComboBoxColumn expenditureType;

        public ExpenditureController()
        {
            _expenditureService = new ExpenditureService();
            expenditureType = new DataGridViewComboBoxColumn();
        }

        public void GetExpenditure(DataGridView dataGridView)
        {
            var res = _expenditureService.GetExpenditureByDateRequest().Select(x => new { x.ExpenditureId, x.TransactionId, x.Description, x.Amount, x.TransactionTimestamp }).ToList();

            IList<ExpenditureTypeItem> list = _expenditureService.GetExpenditureTypes().Select(x => new ExpenditureTypeItem { ExpenditureDesc = x.ExpenditureDesc, ExpenditureTypeId = x.ExpenditureTypeId }).ToList();
            expenditureType.DataSource = list;
            expenditureType.HeaderText = "ExpenditureTypeId";
            expenditureType.DisplayMember = "ExpenditureDesc";
            expenditureType.ValueMember = "ExpenditureTypeId";
            expenditureType.FlatStyle = FlatStyle.Flat;

            dataGridView.DataSource = res;
            if (!isInitialized)
            {
                dataGridView.Columns.Add(expenditureType);
                isInitialized = true;
            }
        }

        public void GetExpenditureTypes(DataGridView dataGridView)
        {
            dataGridView.DataSource = _expenditureService.GetExpenditureTypes().Select(x => new { x.ExpenditureTypeId, x.ExpenditureDesc, x.ExpenditureLimit }).ToList();
        }

        public void GetExpenditureOverview(CircularProgressBar.CircularProgressBar bar1, Label rule1, Label current1, Label limit1,
            CircularProgressBar.CircularProgressBar bar2, Label rule2, Label current2, Label limit2,
            CircularProgressBar.CircularProgressBar bar3, Label rule3, Label current3, Label limit3)
        {
            var expenditureOverview = _expenditureService.GetExpenditureOverview().Select(x => new { x.ExpenditureDesc, x.ExpenditureLimit, x.ExpenditureTotal }).ToList();
            var expenditureTypes = _expenditureService.GetExpenditureTypes().Select(x => new { x.ExpenditureDesc, x.ExpenditureLimit }).ToList();

            if (expenditureTypes.Count >= 1)
            {
                bar1.Maximum = (int)expenditureTypes[0].ExpenditureLimit;
                rule1.Text = expenditureTypes[0].ExpenditureDesc;
            }
            if (expenditureTypes.Count >= 2)
            {
                bar2.Maximum = (int)expenditureTypes[1].ExpenditureLimit;
                rule2.Text = expenditureTypes[1].ExpenditureDesc;
            }
            if (expenditureTypes.Count >= 3)
            {
                bar3.Maximum = (int)expenditureTypes[2].ExpenditureLimit;
                rule3.Text = expenditureTypes[2].ExpenditureDesc;
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

        public void PopluateExpenditurePanel(TableLayoutPanel tableLayoutPanel) {
            var expenditureOverview = _expenditureService.GetExpenditureOverview().Select(x => new { x.ExpenditureDesc, x.ExpenditureLimit, x.ExpenditureTotal }).ToList();
            tableLayoutPanel.Controls.Clear();

            foreach (var item in expenditureOverview)
            {

                //tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                tableLayoutPanel.Controls.Add(new Label()
                {
                    Text = item.ExpenditureDesc.ToString()
                });

                tableLayoutPanel.Controls.Add(new CustomProgressBar()
                {
                    Maximum = (int)item.ExpenditureLimit,
                    Value = (int)item.ExpenditureTotal,
                    BackColor  = System.Drawing.Color.WhiteSmoke,
                    ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(147)))), ((int)(((byte)(137)))))
            });

            }

        }

        public void ImportExpenditure()
        {
            _expenditureService.ImportExpenditure();
        }


        public void SaveExpenditureTypes(SaveExpenditureTypeRequest expenditureRequest)
        {
            _expenditureService.SaveExpenditureTypes(expenditureRequest);
        }

        public void UpdateExpenditure(UpdateExpenditureRequest expenditureRequest)
        {
            _expenditureService.UpdateExpenditure(expenditureRequest);
        }

        public void UpdateExpenditureTypes(UpdateExpenditureTypeRequest expenditureRequest)
        {
            _expenditureService.UpdateExpenditureTypes(expenditureRequest);
        }

        public UpdateExpenditureTypeRequest GetExpenditureSettingsDetailsFromDataGridView(DataGridView dataGridView)
        {
            if (!dataGridView.SelectedRows.Count.Equals(0))
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];
                return new UpdateExpenditureTypeRequest
                {
                    ExpenditureTypeId = int.Parse(selectedRow.Cells[0].Value.ToString()),
                    ExpenditureDesc = selectedRow.Cells[1].Value.ToString(),
                    ExpenditureLimit = decimal.Parse(selectedRow.Cells[2].Value.ToString()),
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
                            ExpenditureTypeId = int.Parse(rows.Cells[0].Value.ToString())
                        });
                    }

                }
            }

        }
    }
}
