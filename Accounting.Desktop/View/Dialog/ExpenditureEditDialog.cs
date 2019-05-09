using Accounting.Desktop.Common;
using Accounting.Desktop.Controller;
using Accounting.Models.Models;
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
    public partial class ExpenditureEditDialog : Form
    {
        private ExpenditureController _expenditureController;
        private MainApplication _mainForm;
        private UpdateExpenditureRequest _updateExpenditureRequest;

        public ExpenditureEditDialog(MainApplication mainForm, UpdateExpenditureRequest updateExpenditureRequest)
        {
            InitializeComponent();
            _expenditureController = new ExpenditureController();
            _mainForm = mainForm;
            _updateExpenditureRequest = updateExpenditureRequest;
            setExpenditure();
        }

        public void setExpenditure()
        {
            textBox3.Text = _updateExpenditureRequest.ExpenditureTypeId.ToString();
        }

        public void saveExpenditure()
        {
            if (Validator.IsNumber(textBox3.Text))
            {
                _expenditureController.UpdateExpenditure(new UpdateExpenditureRequest
                {
                    ExpenditureId = _updateExpenditureRequest.ExpenditureId,
                    ExpenditureTypeId = int.Parse(textBox3.Text),
                });
                _mainForm.PopulateExpenditureTable();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Please enter valid Expenditure Type", "Error", MessageBoxButtons.OK);
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            saveExpenditure();
        }
    }
}
