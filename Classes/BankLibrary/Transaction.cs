using System;

namespace BankLibrary
{
    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }
        public int AccountNumber { get; }

        public Transaction(decimal amount, DateTime date, string note, int accountNumber)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
            this.AccountNumber = accountNumber;
        }
    }
}