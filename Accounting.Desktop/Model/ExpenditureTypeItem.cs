using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Desktop.Model
{
    class ExpenditureTypeItem
    {
        public int ExpenditureTypeId { get; set; }

        public String ExpenditureDesc { get; set; }

        public override string ToString()
        {
            return ExpenditureDesc;
        }
    }
}
