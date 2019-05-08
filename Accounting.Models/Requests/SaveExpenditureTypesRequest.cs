using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Requests
{
    public class SaveExpenditureTypeRequest
    {
        public String ExpenditureDesc { get; set; }

        public Decimal ExpenditureLimit { get; set; }
    }
}
