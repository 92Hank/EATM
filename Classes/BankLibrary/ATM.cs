//Överordnad ATM-klass med ansvar för: Registrering av nytt konto, inloggning på befintligt konto.
using System.Collections.Generic;

namespace BankLibrary
{
    public class ATM
    {
        private static List<BankAccount> allAccounts;
        private static List<BankCard> allBankCards = new List<BankCard>();

        public ATM()
        {
            // Konstruktor som gör det möjligt att komma åt privata listan
            allAccounts = new List<BankAccount>();           
        }

        public List<BankAccount> GetAllAccounts()
        {
            // Skapar en lista som pekar på allAccounts
            List<BankAccount> Accounts;
            return Accounts = allAccounts;
        }

        public List<BankCard> GetAllBankCards()
        {
            // Skapar en lista som pekar på allBankCards
            List<BankCard> allCards;
            return allCards = allBankCards;
        }
        
        public bool Login(int cardNumber, int pinCode)
        {
            int realPincode = allBankCards[cardNumber - 111].GetPincode();

            if (cardNumber >= 111 && cardNumber <= 999 && realPincode == pinCode)
            {
                return true;
            }
            return false;
        }

        public void CheckLoginAttempts(int cardNumber)
        {
            allBankCards[cardNumber - 111].Tries++;
            // Index 0 är 111
            if (allBankCards[cardNumber - 111].Tries >= allBankCards[cardNumber - 111].MaxTries)
            {
                allBankCards[cardNumber - 111].IsLocked = true;               
            }
        }

        public void AddAccountToBank(BankAccount newAccount)
        {
            allAccounts.Add(newAccount);
        }
    }
}