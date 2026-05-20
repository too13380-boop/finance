using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

    namespace FinanceApp
    {
        public class DatabaseHelper 
    

    private string connectionString = "Server=MySQL-8.0;Database=finance_db;login=root;Pwd=;";

        public DataTable GetAllTransactions(string typeFilter = null, string categoryFilter = null,
                                            string dateFrom = null, string dateTo = null)
        {
            DataTable dt = new DataTable();
            string query = "SELECT id, date, type, category, amount, description FROM transactions WHERE 1=1";
            var parameters = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(typeFilter) && typeFilter != "Все")
            {
                query += " AND type = @type";
                parameters.Add(new MySqlParameter("@type", typeFilter == "Доход" ? "income" : "expense"));
            }
            if (!string.IsNullOrEmpty(categoryFilter))
            {
                query += " AND category LIKE @category";
                parameters.Add(new MySqlParameter("@category", "%" + categoryFilter + "%"));
            }
            if (!string.IsNullOrEmpty(dateFrom))
            {
                query += " AND date >= @dateFrom";
                parameters.Add(new MySqlParameter("@dateFrom", dateFrom));
            }
            if (!string.IsNullOrEmpty(dateTo))
            {
                query += " AND date <= @dateTo";
                parameters.Add(new MySqlParameter("@dateTo", dateTo));
            }
            query += " ORDER BY date DESC";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                var adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public void AddTransaction(DateTime date, string type, string category, decimal amount, string description)
        {
            string query = "INSERT INTO transactions (date, type, category, amount, description) VALUES (@date, @type, @category, @amount, @description)";
            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@description", description ?? "");
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateTransaction(int id, DateTime date, string type, string category, decimal amount, string description)
        {
            string query = "UPDATE transactions SET date=@date, type=@type, category=@category, amount=@amount, description=@description WHERE id=@id";
            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@description", description ?? "");
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTransaction(int id)
        {
            string query = "DELETE FROM transactions WHERE id=@id";
            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public (decimal balance, decimal totalIncome, decimal totalExpense, int count) GetStats(string typeFilter = null, string categoryFilter = null,
                                                                                                string dateFrom = null, string dateTo = null)
        {
            DataTable dt = GetAllTransactions(typeFilter, categoryFilter, dateFrom, dateTo);
            decimal totalIncome = 0, totalExpense = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["type"].ToString() == "income")
                    totalIncome += Convert.ToDecimal(row["amount"]);
                else
                    totalExpense += Convert.ToDecimal(row["amount"]);
            }
            return (totalIncome - totalExpense, totalIncome, totalExpense, dt.Rows.Count);
        }
    }
}