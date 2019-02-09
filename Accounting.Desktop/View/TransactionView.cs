using Accounting.Desktop.Controller;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.Desktop.View
{
    public partial class TransactionView : Form
    {
        private TransactionController _transactionController;
        private ExpenseController _ExpenseController;
        private MainApplication _mainform;
        private int _transactionType;

        public TransactionView(TransactionController transactionController, MainApplication mainform, int transactionType)
        {
            InitializeComponent();
            _transactionController = transactionController;
            _ExpenseController = new ExpenseController();
            _mainform = mainform;
            _transactionType = transactionType;
            populateExpenseComboBox();
            getExpenseId();
        }

        public void populateExpenseComboBox()
        {
            _ExpenseController.GetExpenses(comboBox1);
        }

        public void getExpenseId()
        {
            Console.WriteLine();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            _transactionController.SaveTransaction(new TransactionRequest
            {
                Amount = decimal.Parse(textBox1.Text),
                AcounTypetId = int.Parse(textBox2.Text),
                TransactionTypeId = _transactionType,
                ExpenseId = int.Parse(_ExpenseController.GetExpenseId(comboBox1).ToString()),
                Description = textBox3.Text
            });
            _mainform.PopulationTransactionTableGeneralExpenses();
            _mainform.PopulationTransactionTablPersonalExpenses();
            _mainform.PopulationTransactionTableWithdraw();
            _mainform.Recalculate();
            this.Dispose();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
