using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Requests
{
   public class UpdateAccountRequest
    {
        public int AccountId { get; set; }

        public decimal AvailableBalance { get; set; }

    }
}
