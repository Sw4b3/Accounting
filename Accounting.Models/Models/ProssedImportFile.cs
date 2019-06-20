using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Models
{
    public class ProssedImportFiles
    {
        public Guid FileId { get; set; }

        public string Filename { get; set; }

        public int RowCount { get; set; }

        public DateTime ImportDate { get; set; }
    }
}
