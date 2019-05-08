using Accounting.Domain.Services.Service;
using Accounting.Domain.Services.Service.Interface;
using Accounting.Models.Service;
using System;
using System.Collections.Generic;
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
    }
}
