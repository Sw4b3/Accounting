using Accounting.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Accounting.Models.Models
{
    public class ExpenditureViewModel
    { 
        public Guid ExpenditureId { get; set; }

        public Guid TransactionId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime TransactionTimestamp { get; set; }
       
    }
}
