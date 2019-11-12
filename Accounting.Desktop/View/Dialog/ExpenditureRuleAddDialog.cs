using Accounting.Desktop.Common;
using Accounting.Desktop.Controller;
using Accounting.Desktop.Model;
using Accounting.Models.Requests;
using System;
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
            comboBoxExpenditureTypes.DataSource = _expenditureController.GetExpenditureTypes();
        }

        public void SaveExpenditureTypes()
        {
            if (Validator.IsString(textBox3.Text))
            {
                if (Validator.IsNumber(textBox1.Text))
                {
                    _expenditureController.SaveExpenditureRules(new SaveExpenditureTypeRequest
                    {
                        ExpenditureDesc = textBox3.Text,
                        ExpenditureLimit = decimal.Parse(textBox1.Text),
                        ExpenditureTypeId = int.Parse(GetExpenditureTypeId(comboBoxExpenditureTypes).ToString().Trim())
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

        public int GetExpenditureTypeId(ComboBox comboBox)
        {
            return ((ExpenditureTypeItem)comboBox.SelectedItem).ExpenditureTypeId;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveExpenditureTypes();
        }
    }
}
