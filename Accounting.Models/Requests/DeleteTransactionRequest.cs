﻿using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Requests
{
   public class DeleteTransactionRequest
    {
        public Guid TransactionId { get; set; }
    }
}
