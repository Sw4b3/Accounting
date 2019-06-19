using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Requests
{
    public class SaveImportFileRequest
    {
        public string Filename { get; set; }
        public int RowCount { get; set; }
    }
}
