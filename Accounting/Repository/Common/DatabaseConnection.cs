using System.Configuration;

namespace Accounting
{
    public class DatabaseConnection
    {
        public static string connection = ConfigurationManager.AppSettings["ConnectionString"];
    }
}
