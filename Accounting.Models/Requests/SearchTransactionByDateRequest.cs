using System;

namespace Accounting.Models.Requests
{
    public class SearchTransactionByDateRequest
    {
        public int AccountTypeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
