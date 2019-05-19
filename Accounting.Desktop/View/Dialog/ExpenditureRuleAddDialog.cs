using Accounting.Desktop.Common;
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
    public partial class ExpenditureTypeAddDialog : Form
    {
        private ExpenditureController _expenditureController;
        private MainApplication _mainForm;

        public ExpenditureTypeAddDialog(MainApplication mainForm)
        {
            InitializeComponent();
            _expenditureController = new ExpenditureController();
            _mainForm = mainForm;
            PopulateExpenditureTypeComboBox();
        }


        private void PopulateExpenditureTypeComboBox()
        {
            _expenditureController.GetExpenditureTypes(comboBox1);
        }

        public void saveExpenditureTypes()
        {
            if (Validator.IsString(textBox3.Text))
            {
                if (Validator.IsNumber(textBox1.Text))
                {
                    _expenditureController.SaveExpenditureRules(new SaveExpenditureTypeRequest
                    {
                        ExpenditureDesc = textBox3.Text,
                        ExpenditureLimit = decimal.Parse(textBox1.Text),
                        ExpenditureTypeId = int.Parse(_expenditureController.GetExpenditureTypeId(comboBox1).ToString().Trim())
                    });
                    _mainForm.PopulateExpenditureTable();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Please enter valid Limit", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Please enter valid Desciption", "Error", MessageBoxButtons.OK);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            saveExpenditureTypes();
        }
    }
}
