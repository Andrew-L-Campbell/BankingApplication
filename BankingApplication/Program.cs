// Project Prolog
// Name: Andrew Campbell
// CS3260 Section 001
// Project: Lab #03 Banking Program
// Date: 2/4/23
// Purpose: <The purpose of the project is to learn how to use interfaces, inheritance and classes together>
//
// I declare that the following code was written by me or provided
// by the instructor for this project. I understand that copying source
// code from any other source constitutes plagiarism, and that I will receive
// a zero on this project if I am found in violation of this policy.
// ---------------------------------------------------------------------------
namespace BankingApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 04: Banking Application Phase 2\n");
            AccountManager Manager = new AccountManager();//creating an account manager
            int inValue;
            string inName;
            string inAddress;
            while (true)//seeing how many accounts to enter
            {
                Console.WriteLine("How many accounts would you like to create? ");
                string howMany = Console.ReadLine();
                if (howMany == "")
                {
                    Console.WriteLine("You did not enter a correct amount please try again.\n");
                }
                
                else if (int.TryParse(howMany, out int value))
                {
                    inValue = value;
                    if(inValue > 0)
                    {
                        Manager.SetArrayLength(value);//setting array length
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You did not enter a correct amount please try again.\n");
                    }

                }
                else
                {
                    Console.WriteLine("You did not enter a correct amount please try again.\n");
                }
            }
            for(int j = 0; j < inValue; j++)//looping through the amount  for the array
            {

                while (true)//getting name and error validation
                {
                    Console.WriteLine("\nPlease enter the name for the account: ");
                    inName = Console.ReadLine();
                    if (inName == "")//error validation
                    {
                        Console.WriteLine("You did not enter a name please try again: ");
                    }
                    else if (int.TryParse(inName, out int value))
                    {
                        Console.WriteLine("You did not enter a name please try again: ");
                    }
                    else
                    {
                        break;
                    }
                }
                while (true)//getting address and error validation
                {
                    Console.WriteLine("\nPlease enter the Address for the account: ");
                    inAddress = Console.ReadLine();
                    if (inAddress == "")//error validation
                    {
                        Console.WriteLine("You did not enter a Address please try again: ");
                    }
                    else if (int.TryParse(inAddress, out int value))
                    {
                        Console.WriteLine("You did not enter a Address please try again: ");
                    }
                    else
                    {
                        break;
                    }
                }
                while (true)//getting what type of account and error validation
                {
                    Console.WriteLine("What Type of account would you like, Press: 1 - for Checkings, 2 - for Savings, 3 - for CD ");
                    string inOption = Console.ReadLine();
                    if (inOption == "1" || inOption == "2" || inOption == "3")//giving only 3 options to choose from
                    {
                        if (inOption == "1")//For Checking
                        {
                            while (true)// getting initial deposit and error checking
                            {
                                decimal finalAmount;
                                Console.WriteLine("How much do you want to start out with?");
                                string inDeposit = Console.ReadLine();
                                if (inDeposit == "")
                                {
                                    Console.WriteLine("You did not enter a correct amount please try again.\n");
                                }
                                else if (decimal.TryParse(inDeposit, out decimal value))
                                {
                                    finalAmount = value;
                                    if (finalAmount < 10)
                                    {
                                        Console.WriteLine("You need to deposit at least 10$ for checking please try again.");
                                    }
                                    else//setting up account
                                    {
                                        CheckingAccount account = new CheckingAccount();
                                        account.CheckSetBalance(finalAmount);
                                        account.accountServiceFee = 5;
                                        account.CheckSetBalance(value);
                                        account.SetName(inName);
                                        account.SetAddress(inAddress);
                                        account.AccountNumber();
                                        Manager.StoreAccount(account);
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You did not enter a correct amount please try again.\n");
                                }
                               
                            }
                            break;
                            
                        }
                        else if (inOption == "2")//For saving
                        {
                            while (true)//getting initial balance and error validation
                            {
                                decimal finalAmount;
                                Console.WriteLine("How much do you want to start out with?");
                                string inDeposit = Console.ReadLine();
                                if (inDeposit == "")
                                {
                                    Console.WriteLine("You did not enter a correct amount please try again.\n");
                                }
                                else if (decimal.TryParse(inDeposit, out decimal value))
                                {
                                    finalAmount = value;
                                    if (finalAmount < 100)
                                    {
                                        Console.WriteLine("You need to deposit at least 100$ for checking please try again.");
                                    }
                                    else//setting up account
                                    {
                                        SavingAccount account = new SavingAccount();
                                        account.SaveSetBalance(finalAmount);
                                        account.accountServiceFee = 0;
                                        account.SaveSetBalance(value);
                                        account.SetName(inName);
                                        account.SetAddress(inAddress);
                                        account.AccountNumber();
                                        Manager.StoreAccount(account);
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You did not enter a correct amount please try again.\n");
                                }

                            }
                            break;

                        }
                        else//For CD
                        {
                            while (true)//gettting initial deposit and error validation
                            {
                                decimal finalAmount;
                                Console.WriteLine("How much do you want to start out with?");
                                string inDeposit = Console.ReadLine();
                                if (inDeposit == "")
                                {
                                    Console.WriteLine("You did not enter a correct amount please try again.\n");
                                }
                                else if (decimal.TryParse(inDeposit, out decimal value))
                                {
                                    finalAmount = value;
                                    if (finalAmount < 500)
                                    {
                                        Console.WriteLine("You need to deposit at least 500$ for checking please try again.");
                                    }
                                    else//setting up account
                                    {
                                        CDAccount account = new CDAccount();
                                        account.CDSetBalance(finalAmount);
                                        account.accountServiceFee = 8;
                                        account.CDSetBalance(value);
                                        account.SetName(inName);
                                        account.SetAddress(inAddress);
                                        account.AccountNumber();
                                        Manager.StoreAccount(account);
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You did not enter a correct amount please try again.\n");
                                }

                            }
                            break;

                        }
                    }
                    else
                    {
                        Console.WriteLine("You have entered an invalid option, please try again.");//error validation
                    }
                }

                
            }
            Console.WriteLine("\n\nAccount Details-\n");
            Console.WriteLine(Manager);//printing out account details
        }
    }
}