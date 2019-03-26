using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Models
{
   public class Mapping
    {
        public int MappingId { get; set; }

        public string ExpectedString { get; set; }

        public string ProcessedString { get; set; }
    }
}
