﻿using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository.Interface
{
    public interface IBaseReposity
    {
        IList<Transaction> getTransactions(string connectionString, string request);
        void SaveTransactions(string connectionString, string request, TransactionRequest transactions);
    }
}