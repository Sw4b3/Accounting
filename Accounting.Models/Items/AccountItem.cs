using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Desktop.Model
{
    public class AccountItem
    {
        public int AccountId { get; set; }

        public string AccountType { get; set; }

        public override string ToString()
        {
            return AccountType;
        }
    }
}
