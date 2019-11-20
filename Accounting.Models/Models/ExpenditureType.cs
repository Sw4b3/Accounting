using System;

namespace Accounting.Models.Models
{
    public class ExpenditureType
    {
        public int ExpenditureTypeId { get; set; }

        public String ExpenditureDesc { get; set; }

        public Decimal ExpenditureLimit { get; set; }
    }
}
