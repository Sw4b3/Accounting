using Accounting.Desktop.Model;
using Accounting.Repository;
using Accounting.Repository.Interface;
using System.Linq;
using System.Windows.Forms;

namespace Accounting.Desktop.Controller
{
    class ExpenseController
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController()
        {
            _expenseRepository = new ExpenseRepository();
        }

        public void GetExpenses(ComboBox comboBox)
        {
            var expenses = _expenseRepository.GetExpenseRequest().Select(x => new ExpenseItem { ExpenseId = x.ExpenseId, ExpenseType = x.ExpenseType }).ToList();
            comboBox.DataSource = expenses.ToList();
        }

        public int GetExpenseId(ComboBox comboBox)
        {
            return ((ExpenseItem)comboBox.SelectedItem).ExpenseId;
        }
    }
}
