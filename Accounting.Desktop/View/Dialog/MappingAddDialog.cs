using Accounting.Desktop.Common;
using Accounting.Desktop.Controller;
using Accounting.Models.Requests;
using System;
using System.Windows.Forms;

namespace Accounting.Desktop.View
{
    public partial class MappingAddDialog : Form
    {
        private readonly DataImportController _dataImportController;
        private readonly MainApplication _mainForm;

        public MappingAddDialog(MainApplication mainForm)
        {
            InitializeComponent();
            _dataImportController = new DataImportController();
            _mainForm = mainForm;
        }

        public void SaveMapping()
        {
            if (Validator.IsString(nameTextBox.Text))
            {
                _dataImportController.SaveMapping(new SaveMappingRequest
                {
                    ExpectedString = nameTextBox.Text,
                    ProcessedString = numberTextBox.Text,
                });
                _mainForm.PopulateDataImportTables();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Please enter valid Account Name", "Error", MessageBoxButtons.OK);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveMapping();
        }
    }
}
