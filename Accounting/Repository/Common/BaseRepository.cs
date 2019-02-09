using Accounting.Repository.Interface;
using Accounting.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System;
using Accounting.Models.Requests;
using System.Data;

namespace Accounting.Repository.Common
{
    public class BaseRepository : IBaseReposity
    {
        public IList<Transaction> getTransactions(string connectionString, string _transaction)
        {

            IList<Transaction> transactions = new List<Transaction>();

            using (var _connection = new SqlConnection(connectionString))
            {
                _connection.Open();
                using (var command = new SqlCommand(_transaction, _connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var transaction = new Transaction();
                            transaction.TransactionId = (int)reader["TransactionId"];
                            transaction.Description = reader["Description"].ToString().Trim();
                            transaction.Amount = (decimal)reader["Amount"];
                            transaction.Timestamp = DateTime.Parse(reader["TransactionTimestamp"].ToString());
                            transaction.TransactionTypeId = (int)reader["TransactionTypeId"];
                            transaction.ExpenseId = (int)reader["ExpenseId"];
                            transaction.AccountType = (string)reader["AccountType"];
                            transaction.TransactionType = (string)reader["TransactionType"];
                            transactions.Add(transaction);
                        }
                    }
                }
            }

            return transactions;
        }

        public void SaveTransactions(string _connectionString, string _transaction, TransactionRequest request)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(_transaction, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@amount", SqlDbType.Decimal).Value = request.Amount;
                    command.Parameters.AddWithValue("@accountType", SqlDbType.Int).Value = request.AcounTypetId;
                    command.Parameters.AddWithValue("@transactionType", SqlDbType.Int).Value = request.TransactionTypeId;
                    command.Parameters.AddWithValue("@expenseId", SqlDbType.Int).Value = request.ExpenseId;
                    command.Parameters.AddWithValue("@description", SqlDbType.VarChar).Value = request.Description;
                    command.ExecuteNonQuery();
                }
            }
        }

        public IList<Expense> GetExpenses(string connectionString, string _transaction)
        {

            IList<Expense> expenses = new List<Expense>();

            using (var _connection = new SqlConnection(connectionString))
            {
                _connection.Open();
                using (var command = new SqlCommand(_transaction, _connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var expense = new Expense();
                            expense.ExpenseId = (int)reader["ExpenseId"];
                            expense.ExpenseType = reader["ExpenseType"].ToString().Trim();
                            expenses.Add(expense);
                        }
                    }
                }
            }

            return expenses;
        }
    }
}
