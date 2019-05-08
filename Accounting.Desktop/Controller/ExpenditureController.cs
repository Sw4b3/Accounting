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
        IExpenditureService _expenditureService;

        public ExpenditureController()
        {
            _expenditureService = new ExpenditureService();
        }

        public void GetExpenditure(DataGridView dataGridView)
        {
            dataGridView.DataSource = _expenditureService.GetExpenditureByDateRequest().Select(x => new {x.ExpenditureId, x.TransactionId, x.Description, x.Amount, x.TransactionTimestamp, x.ExpenditureTypeId }).ToList(); ;
        }

        public void GetExpenditureTypes(DataGridView dataGridView)
        {
            dataGridView.DataSource = _expenditureService.GetExpenditureTypes().Select(x => new { x.ExpenditureTypeId , x.ExpenditureDesc, x.ExpenditureLimit}).ToList(); 
        }

        public void GetExpenditureOverview(CircularProgressBar.CircularProgressBar bar1,Label rule1, Label current1, Label limit1, 
            CircularProgressBar.CircularProgressBar bar2, Label rule2, Label current2, Label limit2,
            CircularProgressBar.CircularProgressBar bar3, Label rule3, Label current3, Label limit3)
        {
            var expenditureOverview = _expenditureService.GetExpenditureOverview().Select(x => new { x.ExpenditureDesc, x.ExpenditureLimit, x.ExpenditureTotal }).ToList();
            bar1.Maximum =(int) expenditureOverview[0].ExpenditureLimit;
            rule1.Text = expenditureOverview[0].ExpenditureDesc;
            current1.Text = "Current: "+expenditureOverview[0].ExpenditureTotal.ToString();
            limit1.Text = "Limit: " + expenditureOverview[0].ExpenditureLimit.ToString();
            bar2.Maximum = (int)expenditureOverview[1].ExpenditureLimit;
            rule2.Text = expenditureOverview[1].ExpenditureDesc;
            current2.Text = "Current: " + expenditureOverview[1].ExpenditureTotal.ToString();
            limit2.Text = "Limit: " + expenditureOverview[1].ExpenditureLimit.ToString();
            bar3.Maximum = (int)expenditureOverview[2].ExpenditureLimit;
            rule3.Text = expenditureOverview[2].ExpenditureDesc;
            current3.Text = "Current: " + expenditureOverview[2].ExpenditureTotal.ToString();
            limit3.Text = "Limit: " + expenditureOverview[2].ExpenditureLimit.ToString();

            if (expenditureOverview[0].ExpenditureTotal<=expenditureOverview[0].ExpenditureLimit) {
                bar1.Value = (int)expenditureOverview[0].ExpenditureTotal;
            }
            else {
                bar1.Value = (int)expenditureOverview[0].ExpenditureLimit;
                bar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(147)))), ((int)(((byte)(137)))));
            }
            if (expenditureOverview[1].ExpenditureTotal <= expenditureOverview[1].ExpenditureLimit)
            {
                bar2.Value = (int)expenditureOverview[1].ExpenditureTotal;
            }
            else
            {
                bar2.Value = (int)expenditureOverview[1].ExpenditureLimit;
                bar2.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(147)))), ((int)(((byte)(137)))));
            }
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

        public void SaveExpenditureTypes(SaveExpenditureTypeRequest expenditureRequest)
        {
           _expenditureService.SaveExpenditureTypes(expenditureRequest);
        }
    }
}
