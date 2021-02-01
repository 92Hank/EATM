using System;
using System.Collections.Generic;
using BankLibrary;

namespace TestData
{
    public class BankCardTest
    {
        // ATM testATM;
        // List<BankAccount> testCopyAccounts;
        // public string inputAccount;
        // public string pinCode;
        // public int tries = 0;
        // public int maxTries = 3;
        //public void EnterAccountNumberAndPinCode()
        //{
            //var user = new BankAccount("Pär", 1234, 10000, false);
            //var user2 = new BankAccount("Anton", 5678, 15000, false);
            //var user3 = new BankAccount("Olle", 1122, 20000, false);
            //var user4 = new BankAccount("Ove", 1113, 20000, false);
            //bool pass = false;

            //while (!pass)
            //{
                //Försök hitta användare och logga in
                //Ta emot användarnamn och lösenord
                //Console.WriteLine("Account number: ");
                //inputAccount = Console.ReadLine();
                //Console.WriteLine("Pin Code: ");
                //pinCode = Console.ReadLine();
                //if (user.AccountNumber.Equals(inputAccount) && user.AccountPinCode.Equals(pinCode))
                //{
                    //Console.WriteLine($"{user.Owner} is now logged in.");
                    //Console.WriteLine($"Account number: {user.AccountNumber} Balance: {user.Balance}");
                    //pass = true;
                //}
                //else if (user2.AccountNumber.Equals(inputAccount) && user2.AccountPinCode.Equals(pinCode))
                //{
                    //Console.WriteLine($"{user2.Owner} is now logged in.");
                    //Console.WriteLine($"Account number: {user2.AccountNumber} Balance: {user2.Balance}");
                    //pass = true;
                //}
                //else if (user3.AccountNumber.Equals(inputAccount) && user3.AccountPinCode.Equals(pinCode))
                //{
                    //Console.WriteLine($"{user3.Owner} is now logged in.");
                    //Console.WriteLine($"Account number: {user3.AccountNumber} Balance: {user3.Balance}");
                    //pass = true;
               // }
                //else if (user4.AccountNumber.Equals(inputAccount) && user4.AccountPinCode.Equals(pinCode))
                //{
                    //Console.WriteLine($"{user4.Owner} is now logged in.");
                    //Console.WriteLine($"Account number: {user4.AccountNumber} Balance: {user4.Balance}");
                    //pass = true;
               // }
                //else
                //{
                    //pass = false;
                    //BankAccount checkAccount = Login(inputAccount, test, pinCode, 100, false);
                    //tries++;
                    //if (tries >= maxTries)
                    //{
                        //user.isLocked = true;
                        //Console.WriteLine("Your account is locked...");
                        //System.Environment.Exit(1);
                    //}

                    //System.Console.WriteLine($"Wrong accountnumber or pincode, try again.. {tries} tries out of {maxTries}");
                //}
                //System.Console.ReadLine();
            //}
        //}
        //public BankCardTest(ATM ATM)
        //{
            //this.testATM = ATM;
            //this.testCopyAccounts = testATM.GetAllAccounts();
            // CreateTestUsers();
            //CreateTestTransactions();
        //}

        // public void CreateTestTransactions()
        // {
        //     testCopyAccounts[0].ChangeBalance(-50, DateTime.Now, "Xbox Game");
        //     testCopyAccounts[0].ChangeBalance(-120, DateTime.Now, "Hammock");
        //     testCopyAccounts[0].ChangeBalance(100, DateTime.Now, "Friend paid me back");
        //     testCopyAccounts[0].ChangeBalance(-5, DateTime.Now, "Coffee");
        //     testCopyAccounts[0].ChangeBalance(-7, DateTime.Now, "Tea");
        //     testCopyAccounts[0].ChangeBalance(-8, DateTime.Now, "Pants");
        // }

        //public void CreateTestUsers()
        //{
            //BankAccount test1 = new BankAccount("Pär", 1234, 10000);
            //BankAccount test2 = new BankAccount("Anton", 9999);
            //BankAccount test3 = new BankAccount("Olle", 4321, 5);
            //BankAccount test4 = new BankAccount("Ove", 1010, 2);

            //testCopyAccounts.Add(test1);
            //testCopyAccounts.Add(test2);
            //testCopyAccounts.Add(test3);
            //testCopyAccounts.Add(test4);
        //}
    }
}