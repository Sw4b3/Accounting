using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Services.Utillies
{
    public class Extensions
    {
        public static DateRequest GetCurrentMonth()
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            return new DateRequest()
            {
                StartDate = startDate,
                EndDate = endDate
            };
        }

        public static DateRequest GetMonths()
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            var endDate = DateTime.Now.Date;

            return new DateRequest()
            {
                StartDate = startDate,
                EndDate = endDate
            };
        }
    }
}
