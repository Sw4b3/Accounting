using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Accounting.Desktop.Common
{
    public class Validator
    {
        public bool IsString(string request) {
            string pattern = "[A-Za-z]";
            return Regex.IsMatch(request, pattern);
        }

        public bool IsNumber(string request)
        {
            string pattern = "[0-9]";
            return Regex.IsMatch(request, pattern);
        }
    }
}
