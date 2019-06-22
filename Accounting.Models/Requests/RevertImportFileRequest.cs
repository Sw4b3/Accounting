using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Requests
{
    public class RevertImportFileRequest
    {
       public Guid FileId { get; set; }
    }
}
