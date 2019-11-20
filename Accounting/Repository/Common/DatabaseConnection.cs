using System.Configuration;

namespace Accounting
{
    class DatabaseConnection
    {
        public static string connection = ConfigurationManager.AppSettings["ConnectionString"];
    }
}
