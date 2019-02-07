using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.Desktop.Controller;
using Accounting.Repository;

namespace Accounting.Desktop
{
    public partial class MainApplication : Form
    {
        private TransactionController _TransactionController;

        public MainApplication()
        {
            InitializeComponent();
            _TransactionController = new TransactionController();
            PopulationTransactionTable();
        }

        public void PopulationTransactionTable()
        {
            _TransactionController.BindClass(dataViewTransaction);
        }
    }
}
