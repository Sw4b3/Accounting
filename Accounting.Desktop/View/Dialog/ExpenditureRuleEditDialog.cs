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
    public partial class ExpenditureTypeEditDialog : Form
    {
        private ExpenditureController _expenditureController;
        private MainApplication _mainForm;
        private UpdateExpenditureRuleRequest _updateExpenditureTypeRequest;

        public ExpenditureTypeEditDialog(MainApplication mainForm, UpdateExpenditureRuleRequest updateExpenditureTypeRequest)
        {
            InitializeComponent();
            _expenditureController = new ExpenditureController();
            _mainForm = mainForm;
            _updateExpenditureTypeRequest = updateExpenditureTypeRequest;
            SetExpenditure();
        }

        public void SetExpenditure()
        {
            this.Text = _updateExpenditureTypeRequest.ExpenditureDesc+" Rule";
            textBox3.Text = _updateExpenditureTypeRequest.ExpenditureDesc;
            textBox1.Text = _updateExpenditureTypeRequest.ExpenditureLimit.ToString();
            checkBox1.Checked= _updateExpenditureTypeRequest.ShouldDisplay;
        }

        public void SaveExpenditureTypes() {
            if (Validator.IsString(textBox3.Text))
            {
                if (Validator.IsNumber(textBox1.Text))
                {
                    _expenditureController.UpdateExpenditureRule(new UpdateExpenditureRuleRequest
                    {
                        ExpenditureRuleId = _updateExpenditureTypeRequest.ExpenditureRuleId,
                        ExpenditureDesc = textBox3.Text,
                        ExpenditureLimit = decimal.Parse(textBox1.Text),
                        ShouldDisplay = checkBox1.Checked
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
            SaveExpenditureTypes();
        }
    }
}
