using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Requests
{
   public class TransactionByDateRequest
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
