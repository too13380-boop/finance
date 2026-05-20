using System;

namespace FinanceApp
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }  // "income" или "expense"
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}