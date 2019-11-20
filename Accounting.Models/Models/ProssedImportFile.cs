using System;

namespace Accounting.Models.Models
{
    public class ProssedImportFiles
    {
        public Guid FileId { get; set; }

        public string Filename { get; set; }

        public int RowCount { get; set; }

        public DateTime ImportDate { get; set; }

        public string Status { get; set; }

    }
}
