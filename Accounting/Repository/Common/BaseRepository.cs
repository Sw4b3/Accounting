using Accounting.Repository.Interface;
using Accounting.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;

namespace Accounting.Repository.Common
{
   public class BaseRepository: IBaseReposity
    {
        public  IList<Transaction> getTransactions(string connectionString, string request) {

            IList <Transaction> transactions = new List<Transaction>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand(request, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var transaction = new Transaction();
                            transaction.TransactionId = (int)reader["TransactionId"];
                            transaction.Amount = (decimal)reader["Amount"];
                            transaction.Timestamp =DateTime.Parse( reader["Timestamp"].ToString());
                            transaction.TransactionTypeId = (int)reader["TransactionTypeId"];
                            transaction.AcounTypetId = (int)reader["AcounTypetId"];

                            transactions.Add(transaction);
                        }
                    }
                }
            }

            return transactions;
        }
    }
}
