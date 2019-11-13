using Accounting.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Accounting.Models.ViewModels
{
    public class ExpenditureBreakdownViewModel
    {
        public string ExpenditureDesc { get; set; }

        public decimal ExpenditureLimit { get; set; }

        public decimal ExpenditureTotal { get; set; }

        public decimal Difference { get; set; }
    }
}
