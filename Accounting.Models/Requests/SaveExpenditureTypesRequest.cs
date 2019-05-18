using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Requests
{
    public class SaveExpenditureTypeRequest
    {
        public string ExpenditureDesc { get; set; }

        public decimal ExpenditureLimit { get; set; }

        public int ExpenditureTypeId { get; set; }
    }
}
