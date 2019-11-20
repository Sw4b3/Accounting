using System.Text.RegularExpressions;

namespace Accounting.Desktop.Common
{
    public class Validator
    {
        public static bool IsString(string request)
        {
            string pattern = "[A-Za-z]";
            return Regex.IsMatch(request, pattern);
        }

        public static bool IsNumber(string request)
        {
            string pattern = "[0-9]";
            return Regex.IsMatch(request, pattern);
        }
    }
}
