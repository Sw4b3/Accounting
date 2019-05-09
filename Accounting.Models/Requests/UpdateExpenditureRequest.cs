using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Models
{
    public class UpdateExpenditureRequest
    {
        public Guid ExpenditureId { get; set; }

        public int ExpenditureTypeId { get; set; }

    }
}
