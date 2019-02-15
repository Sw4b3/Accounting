using Accounting.Desktop.Model;
using Accounting.Domain.Services.Service;
using System.Linq;
using System.Windows.Forms;

namespace Accounting.Desktop.Controller
{
    class ExpenseController
    {
        private readonly ExpenseServices _expenseServices;

        public ExpenseController()
        {
            _expenseServices = new ExpenseServices();
        }

        public void GetExpenses(ComboBox comboBox)
        {
            var expenses = _expenseServices.GetExpenses().Select(x => new ExpenseItem { ExpenseId = x.ExpenseId, ExpenseType = x.ExpenseType }).ToList();
            comboBox.DataSource = expenses.ToList();
        }

        public int GetExpenseId(ComboBox comboBox)
        {
            return ((ExpenseItem)comboBox.SelectedItem).ExpenseId;
        }
    }
}
