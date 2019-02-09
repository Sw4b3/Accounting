using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Desktop.Model
{
    class ExpenseItem
    {
        public int ExpenseId { get; set; }

        public string ExpenseType { get; set; }

        public override string ToString()
        {
            return ExpenseType;
        }
    }
}
