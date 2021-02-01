using System;
using BankLibrary;

namespace ConsoleClasses
{
    public class TextOutput
    {
public static void PrintMenuOptions()
        {
            Console.WriteLine("__________________________");
            Console.WriteLine("|                         |");
            Console.WriteLine("|-------E-ATM Bank--------|");
            Console.WriteLine("|-------------------------|");
            Console.WriteLine("|  [1]Register new user.  |");
            Console.WriteLine("|  [2]Proceed to log in.  |");
            Console.WriteLine("|  [3]Quit.               |");
            Console.WriteLine("|                         |");
            Console.WriteLine("|_________________________|");
        }

        public static void PrintAccountMenu()
        {
            Console.WriteLine("__________________________");
            Console.WriteLine("|                         |");
            Console.WriteLine("|-------E-ATM Bank--------|");
            Console.WriteLine("|-------------------------|");
            Console.WriteLine("|  [1]Deposit Money       |");
            Console.WriteLine("|  [2]Withdraw Money      |");
            Console.WriteLine("|  [3]Show current balance|");
            Console.WriteLine("|  [4]Show Transactions   |");
            Console.WriteLine("|  [5]Return to main menu |");
            Console.WriteLine("|_________________________|");
        }
        
        public static void NewAccountPrompt()
        {
            Console.WriteLine("\nRegistering new account...");
        }

        public static void LoginPrompt()
        {
            Console.WriteLine("\nPlease enter login details.");
        }   

        public static void QuitProgrammeMessage()
        {
            Console.WriteLine("\n\nClosing application...");
        }

        public static void InputKeyErrorMessage(Exception e)
        {
            Console.WriteLine("An error has occured, please view the error message.\n", e);
        }

        public static void WrongChoiceMessage()
        {
            Console.WriteLine("\nYou have selected an invalid choice, please try again");
        }

        public static void DepositMoneyPrompt()
        {
            Console.WriteLine("\n\nPlease enter sum to deposit (positive value, comma for decimals).");
        }

        public static void WithdrawMoneyPrompt()
        {
            Console.WriteLine("\n\nPlease enter sum to withdraw (positive value, comma for decimals).");
        }

        public static void ShowBalance(BankAccount account)
        {
            Console.WriteLine("\n\nYour account balance is {0} SEK.", account.Balance);
        }

        public static void DisplayTransactions(BankAccount account)
        {
            Console.WriteLine("\n" + account.GetAccountHistory());
        }

        public static void PrintWrongCardOrPin()
        {
            Console.WriteLine("Wrong card number or pincode, try again..");
        }

        public static void PrintWrongCardOrPin(BankCard bankCard)
        {
            Console.WriteLine($"Wrong card number or pincode, try again.. {bankCard.Tries} tries out of 3");
        }

        public static void PrintUserinfo(string owner, int accountNumber)
        {
            Console.WriteLine($"{owner} is now logged in.\nAccount number: {accountNumber}");
        }

        public static void ConfirmationNewCardinfo(string owner, int accountNumber)
        {
            Console.WriteLine($"An account for ({owner}) is now created.\nCardnumber is: {accountNumber}");
        }

        public static void EnterTransactionNote()
        {
            Console.WriteLine("Enter a transaction note.");
        }

        public static void WrongFormatError()
        {
            Console.WriteLine("Wrong format, try again.");
        }

        public static void NumericalOverflowError()
        {
            Console.WriteLine("Entered number is too large, try again.");
        }

        public static void InvalidNegativeValue()
        {
            Console.WriteLine("\nYou must enter a positive value!");
        }

        public static void InsufficientFundsPrompt()
        {
            Console.WriteLine("\nNot sufficient funds for this withdrawal.");
        }

        public static void PrintEmptyAccount()
        {
            Console.WriteLine("\nYou have less than 1 SEK deposited and cannot withdraw money.");
        }

        public static void EnterCardNumber()
        {
            Console.WriteLine("Select a bank card number.");
        }

        public static void EnterAccountNumber()
        {
            Console.WriteLine("Enter AccountNumber!");
        }
        
        public static void EnterPinCode()
        {
            Console.WriteLine("Enter pin code of 4 digits.");
        }

        public static void EnterOwner()
        {
            Console.WriteLine("Enter name of acount owner.");
        }
    
        public static void PressToContinue()
        {
            Console.WriteLine("Press any key to continue...");
        }

        public static void PrintAccountNumber(int accountNumber)
        {
            Console.WriteLine("Your account number is {0}. Please remember it for future use.", accountNumber);
        }

        public static void IncorrectNumberOfDigits()
        {
            Console.WriteLine("Incorrect number of digits. Try again.");
        }

        public static void PrintLockedBankCard()
        {
            Console.WriteLine("The bank card is locked. Login impossible.");
        }
    }
}
