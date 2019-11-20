using System;

namespace Accounting.Desktop.Model
{
    public class ExpenditureTypeItem
    {
        public int ExpenditureTypeId { get; set; }

        public String ExpenditureDesc { get; set; }

        public override string ToString()
        {
            return ExpenditureDesc;
        }
    }
}
