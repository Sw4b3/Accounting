﻿using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Services.Service.Interface
{
    public interface ITransactionService
    {
        IList<Transaction> GetTransactionsByDate(GetTransactionByDateRequest transaction);

        IList<TransactionAnalysis> GetTransactionAnalysis();

        IList<TransactionAnalysisByDay> GetTransactionAnalysisByDay();

        void SaveTransaction(GetTransactionRequest transaction);

        void UpdateTransaction(UpdateTransactionRequest transaction);
    }
}
