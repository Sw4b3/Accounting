﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Requests
{
    public class AccountRequest
    {
        public int AccountId { get; set; }

        public string AccountType { get; set; }
    }
}
