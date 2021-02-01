using System;
using System.Collections.Generic;

namespace BankLibrary
{
    public class BankAccount
    {
        private static int accountNumberSeed = 1234567890;
        private static List<Transaction> allTransactions = new List<Transaction>();

        public int AccountNumber { get; set; }
        public string Owner { get; set; }
        public decimal Balance { get; set; }
        public BankCard AccountCard { get; set; }
        // Konstruktor för att initiera objekt av denna klassen/typen
        public BankAccount(string name)
        {
            this.AccountNumber = accountNumberSeed;
            accountNumberSeed++;
            this.Owner = name;

            this.Balance = 0;
        }

        public BankAccount(string name, decimal initialBalance)
        {
            this.AccountNumber = accountNumberSeed;
            accountNumberSeed++;
            this.Owner = name;

            this.Balance = 0;
            ChangeBalance(initialBalance, DateTime.Now, "initial balance");
        }

        public void RegisterCard(int pinCode, List<BankCard> allBankCards)
        {
            BankCard newCard = new BankCard(pinCode, false);
            AccountCard = newCard;
            allBankCards.Add(newCard);
        }

        // Funktionalitet: Skapar en transaktion baserad på inputparametrar. Relevant kontos saldo beräknas på det.
        //
        public void ChangeBalance(decimal amount, DateTime date, string note)
        {
            this.Balance += amount;
            RegisterTransaction(amount, date, note);
        }

        public void RegisterTransaction(decimal amount, DateTime date, string note)
        {
            Transaction deposit = new Transaction(amount, date, note, this.AccountNumber);
            allTransactions.Add(deposit);
        }

        // Funktionalitet: Skapar sträng med rubrik och listar därunder alla transaktioner med löpande
        //                 aktuellt saldo. Endast transaktioner till/från rätt konto listas.
        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();
            decimal balance = 0;

            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                if (item.AccountNumber == AccountNumber)
                {
                    balance += item.Amount;
                    report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
                }
            }
            return report.ToString();
        }
    }
}