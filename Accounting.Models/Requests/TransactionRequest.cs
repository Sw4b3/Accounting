﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Requests
{
    public class TransactionRequest
    {
        public decimal Amount { get; set; }

        public int TransactionTypeId { get; set; }

        public int AcounTypetId { get; set; }

        public string Description { get; set; }

        public int ExpenseId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
