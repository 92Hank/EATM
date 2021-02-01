using System;
using BankLibrary;

namespace ConsoleClasses
{
    public class AccountMenu
    {
        public static void ActivateAccountMenu(BankAccount currentAccount)
        { 
            ConsoleKey keyChoice;
            InputCheck inputCheck = new InputCheck();

            while (true)
            {
                TextOutput.PrintUserinfo(currentAccount.Owner, currentAccount.AccountNumber);
                TextOutput.PrintAccountMenu();

                keyChoice = inputCheck.GetKeyInput();
                
                switch (keyChoice)
                {
                    case ConsoleKey.D1:
                        TextOutput.DepositMoneyPrompt();
                        inputCheck.MakeDeposit(currentAccount);
                        inputCheck.ClearConsole();
                        break;
                    case ConsoleKey.D2: 
                        inputCheck.MakeWithdrawal(currentAccount);
                        inputCheck.ClearConsole();
                        break;
                    case ConsoleKey.D3:
                        TextOutput.ShowBalance(currentAccount);
                        inputCheck.ClearConsole();
                        break;
                    case ConsoleKey.D4:
                        TextOutput.DisplayTransactions(currentAccount);
                        inputCheck.ClearConsole();
                        break;
                    case ConsoleKey.D5:
                        return;
                    default:
                        TextOutput.WrongChoiceMessage();
                        inputCheck.ClearConsole();
                        break;
                }
            }
        }
    }
}