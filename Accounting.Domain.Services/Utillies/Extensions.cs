using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Services.Utillies
{
    public static class Extensions
    {
        public static GetDateRequest GetCurrentMonth()
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            return new GetDateRequest()
            {
                StartDate = startDate,
                EndDate = endDate
            };
        }
    }
}
