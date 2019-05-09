using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting
{
    class DatabaseConnection
    {
        public static string connection = ConfigurationManager.AppSettings["ConnectionString"];
    }
}
