﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Models
{
    public class Account
    {
        public string AccountNo { get; set; }

        public int AccountId { get; set; }

        public string AccountType { get; set; }

        public decimal CurrentBalance { get; set; }

        public decimal AvailableBalance { get; set; }

        public string Status { get; set; }
    }
}
