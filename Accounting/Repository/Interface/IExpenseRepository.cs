using Accounting.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository.Interface
{
    public interface IExpenseRepository
    {
        IList<Expense> GetExpenseRequest();
    }
}
