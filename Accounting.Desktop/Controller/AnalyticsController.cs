﻿using Accounting.Domain.Services.Service;
using Accounting.Domain.Services.Utillies;
using Accounting.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Accounting.Desktop.Controller
{
    class AnalyticsController
    {
        TransactionService _transactionService;
        AnalyticsService _analyticsService;

        public AnalyticsController()
        {
            _transactionService = new TransactionService();
            _analyticsService = new AnalyticsService();
        }


        public void GetAnalyticsOverview(DataGridView dataGridView)
        {
            dataGridView.DataSource = _analyticsService.GetAnalysicOverview();
        }

        public void GetAnalyticStatistics(DataGridView dataGridView)
        {
            dataGridView.DataSource = _analyticsService.GetStatistics();
        }

        public void GetAnalyticsOverview(Chart chartPie)
        {
            var accountDetails = _transactionService.GetTransactionsByDate(Extensions.GetCurrentMonth());
            var expense = accountDetails.Where(x => x.TransactionTypeId == 2 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();
            var income = accountDetails.Where(x => x.TransactionTypeId == 1 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();

            chartPie.Series[0].Points.DataBindXY(new[] { "Expense", "Income" }, new[] { expense, income });
        }

        public void GetAnalyticsByDay(DataGridView dataGridView, Chart chartBar)
        {
            var transaction = _analyticsService.GetAnalyticsByDay();
            var dayAnalytics = transaction.Select(x => x.Amount).ToList();
            var dayAnalyticsHeader = transaction.Select(x => x.TransactionTimestamp.ToString("dd/MMM")).ToList();

            chartBar.Series[0].Points.DataBindXY(dayAnalyticsHeader, dayAnalytics);
            dataGridView.DataSource = transaction;
        }

        public void GetAnalyticsByMonth(DataGridView dataGridView, Chart chartColumn)
        {
            var transaction = _analyticsService.GetAnalyticsByMonth();
            var credit = transaction.Select(x => x.Credit).ToList();
            var debit = transaction.Select(x => -x.Debit).ToList();
            var balance = transaction.Select(x => x.Balance).ToList();
            var month = transaction.Select(x => x.Date.ToString("MMM")).ToList();

            chartColumn.Series[0].Points.DataBindXY(month, credit);
            chartColumn.Series[1].Points.DataBindXY(month, debit);
            chartColumn.Series[2].Points.DataBindXY(month, balance);

            dataGridView.DataSource = transaction;
        }
    }
}
