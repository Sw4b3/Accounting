﻿using Accounting.Models.Requests;
using System;

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

        public static bool IsMatch(string value1, string value2, decimal value3, decimal value4, DateTime importedDate, DateTime pendingDate)
        {

            if (value1.ToLower().Contains(value2.ToLower()) && value3.ToString("0.00").Equals(value4.ToString("0.00")) && (importedDate.AddDays(-4) >= pendingDate || pendingDate <= importedDate.AddDays(4)))
            {
                return true;
            }
            return false;
        }
    }
}
