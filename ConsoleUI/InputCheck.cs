using System;
using BankLibrary;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleClasses
{
    public class InputCheck
    {
        public ConsoleKey GetKeyInput()
        {
            ConsoleKey keyinput = 0;
            try
            {
                keyinput = Console.ReadKey().Key;
            }
            catch (System.InvalidOperationException e)
            {
                TextOutput.InputKeyErrorMessage(e);
            }

            return keyinput;
        }

        public decimal GetValidDecimal()
        {
            bool validValue = false;
            decimal value = 0;

            do
            {
                try
                {
                    value = Decimal.Parse(Console.ReadLine());
                    validValue = true;
                }
                catch (System.FormatException)
                {
                    TextOutput.WrongFormatError();
                }
                catch (System.OverflowException)
                {
                    TextOutput.NumericalOverflowError();
                }
            }
            while (!validValue);

            return value;
        }

        public int GetValidInteger()
        {
            bool isValidValue = false;
            int value = 0;

            do
            {
                try
                {
                    value = Int32.Parse(Console.ReadLine());
                    isValidValue = true;
                }
                catch (System.FormatException)
                {
                    TextOutput.WrongFormatError();
                }
                catch (System.OverflowException)
                {
                    TextOutput.NumericalOverflowError();
                }
            }
            while (!isValidValue);

            return value;
        }

        public int GetValidInteger(int max, int min)
        {
            bool isValidValue = false;
            string inputstring;
            int value = 0;

            do
            {
                try
                {
                    inputstring = Console.ReadLine();
                    value = Int32.Parse(inputstring);
                    isValidValue = true;
                    if (!HasNumberOfCharacters(inputstring, max, min)) isValidValue = false;
                }
                catch (System.FormatException)
                {
                    TextOutput.WrongFormatError();
                }
                catch (System.OverflowException)
                {
                    TextOutput.NumericalOverflowError();
                }
            }
            while (!isValidValue);

            return value;
        }

        public bool HasNumberOfCharacters(string inputstring, int max, int min)
        {
            if (inputstring.Length > max || inputstring.Length < min)
            {
                TextOutput.IncorrectNumberOfDigits();
                return false;
            }
            else return true;
        }

        // Funktionalitet: Testar om decimaltalsvärde är lika med eller mindre än 0. Om så måste nytt värde ges av användaren.
        //
        public decimal GetPositiveDecimal()
        {
            decimal decimalValue = GetValidDecimal();

            while (decimalValue <= 0)
            {
                TextOutput.InvalidNegativeValue();
                decimalValue = GetValidDecimal();
            }

            return decimalValue;
        }

        public void ClearConsole()
        {
            TextOutput.PressToContinue();
            Console.ReadKey();
            Console.Clear();
            while (Console.KeyAvailable) Console.ReadKey(false);
        }

        /* === BANKSPECIFIKA INPUTMETODER === */

        public void MakeDeposit(BankAccount account)
        {
            decimal depositedValue = GetPositiveDecimal();
            string transactionNote = GetTransactionNote();

            account.ChangeBalance(depositedValue, DateTime.Now, transactionNote);
        }

        public void MakeWithdrawal(BankAccount account)
        {
            if (IsAccountEmpty(account)) return;

            TextOutput.WithdrawMoneyPrompt();
            decimal withdrawnValue = GetValidWithdrawalValue(account);
            string transactionNote = GetTransactionNote();

            account.ChangeBalance(-withdrawnValue, DateTime.Now, transactionNote);
        }

        public string GetTransactionNote()
        {
            TextOutput.EnterTransactionNote();
            return Console.ReadLine();
        }

        public bool IsAccountEmpty(BankAccount account)
        {
            if (account.Balance < 1)
            {
                TextOutput.PrintEmptyAccount();
                return true;
            }
            else return false;
        }

        public decimal GetValidWithdrawalValue(BankAccount account)
        {
            bool validWithdrawal = false;
            decimal withdrawValue = 0;

            while (!validWithdrawal)
            {
                withdrawValue = GetPositiveDecimal();

                if (withdrawValue > account.Balance) TextOutput.InsufficientFundsPrompt();
                else validWithdrawal = true;
            }
            return withdrawValue;
        }

        public int GetCardNumber()
        {
            TextOutput.EnterCardNumber();
            int cardNumber = GetValidInteger(3, 3);
            return cardNumber;
        }

        public int GetPinCode()
        {
            TextOutput.EnterPinCode();
            int pinCode = GetValidInteger(4, 4);
            return pinCode;
        }
       
        public string GetAccountOwner()
        {
            TextOutput.EnterOwner();
            string ownerName = Console.ReadLine();
            for (int tries = 0; !Regex.IsMatch(ownerName, @"^[A-Za-z]+$"); tries++)
            {
                if (tries > 0)
                    Console.WriteLine("Please enter name in the correct format");
                else
                    Console.WriteLine("Please enter name, only letters");
                ownerName = Console.ReadLine().Trim();
            }
            return ownerName;
        }

        public void LoginUser(ATM ATM)
        {
            int cardNumber = GetCardNumber();
            int pinCode = GetPinCode();
            List<BankCard> copiesOfBankCards = ATM.GetAllBankCards();

            if (!DoesCardExist(cardNumber, copiesOfBankCards) || IsCardLocked(copiesOfBankCards[cardNumber - 111])) return;
            bool loginStatus = ATM.Login(cardNumber, pinCode);
            HandleLoginAttempt(ATM, loginStatus, cardNumber, copiesOfBankCards);
        }

        // Funktionalitet: Hanterar inloggning och skickar användare vidare till AccountMenu om man är inloggad.
        // Om man misslyckas med att logga in har man 3 försök på sig innan kontot spärras.
        public void HandleLoginAttempt(ATM ATM, bool isLoggedIn, int cardNumber, List<BankCard> copiesOfBankCards)
        {
            if (isLoggedIn)
            {
                List<BankAccount> accountsCopy = ATM.GetAllAccounts();
                BankAccount loggedinAccount = accountsCopy[cardNumber - 111];
                AccountMenu.ActivateAccountMenu(loggedinAccount);
            }
            else
            {
                TextOutput.PrintWrongCardOrPin(copiesOfBankCards[cardNumber - 111]);
                ATM.CheckLoginAttempts(cardNumber);
                if (!DoesCardExist(cardNumber, copiesOfBankCards) || IsCardLocked(copiesOfBankCards[cardNumber - 111])) return;
            }
        }

        public bool DoesCardExist(int cardNumber, List<BankCard> copiesOfCards)
        {
            if(copiesOfCards.Count == 0 || cardNumber < copiesOfCards[0].CardNumber || cardNumber > copiesOfCards[copiesOfCards.Count - 1].CardNumber)
            {
                TextOutput.PrintWrongCardOrPin();
                return false;
            }
            else return true;
        }

        public bool IsCardLocked(BankCard bankCard)
        {
            if (bankCard.IsLocked)
            {
                TextOutput.PrintLockedBankCard();
                return true;
            }
            else return false;
        }

        // Funktionalitet: Låter användare mata in pinkod och kontoinnehavares namn fritt. BankAccount och BankCard registreras.
        //
        public void RegisterAccount(ATM ATM)
        {
            int pinCode = GetPinCode();
            string accountOwner = GetAccountOwner();
            
            BankAccount newAccount = new BankAccount(accountOwner);
            ATM.AddAccountToBank(newAccount);

            List<BankCard> temporaryCardList = ATM.GetAllBankCards();
            newAccount.RegisterCard(pinCode, temporaryCardList);
            var cardNumber = GetNewestCardNumber(newAccount, temporaryCardList);
            TextOutput.ConfirmationNewCardinfo(accountOwner, cardNumber);
        }

        // Funktionalitet: Eftersom allBankCards är privat i Account-klassen kan man inte bara hämta den och ta ett kontos nummer.
        // Istället måste man hämta en identisk kopia på allBankCards, söka efter sista kortet i listan, och ta det kortnumret.
        public int GetNewestCardNumber(BankAccount newAccount, List<BankCard> temporaryCardList)
        {
            return temporaryCardList[temporaryCardList.Count - 1].CardNumber;
        }
    }
}
