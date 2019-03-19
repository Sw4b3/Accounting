using Accounting.Domain.Services.Service.Interface;
using Accounting.Models.Models;
using Accounting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Services.Service
{
    public class ExpenseServices: IExpenseService
    {
        private readonly UnitOfWork uow;

        public ExpenseServices()
        {
            uow = new UnitOfWork();
        }

        public IList<Expense> GetExpenses()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.ExpenseRepository.GetExpenseRequest();
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
