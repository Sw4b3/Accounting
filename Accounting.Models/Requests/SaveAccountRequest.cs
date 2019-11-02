using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Requests
{
    public class SaveAccountRequest
    {
        public string AccountType { get; set; }
        public string AccountNo { get; set; }
    }
}
