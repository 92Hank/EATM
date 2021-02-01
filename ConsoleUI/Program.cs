using System;
using ConsoleClasses;
using BankLibrary;
using TestData;

namespace _20HSUOP_projektarbete
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey keyChoice;
            ATM newATM = new ATM();
            InputCheck inputCheck = new InputCheck();
            //BankCardTest testData = new BankCardTest(newATM);

            while (true)
            {
                TextOutput.PrintMenuOptions();
                keyChoice = inputCheck.GetKeyInput();
                
                switch (keyChoice)
                {
                    case ConsoleKey.D1:
                        TextOutput.NewAccountPrompt();
                        inputCheck.RegisterAccount(newATM);
                        inputCheck.ClearConsole();
                        break;
                    case ConsoleKey.D2: 
                        TextOutput.LoginPrompt();
                        inputCheck.LoginUser(newATM);
                        inputCheck.ClearConsole();
                        break;
                    case ConsoleKey.D3:
                        TextOutput.QuitProgrammeMessage();
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

