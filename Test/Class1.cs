using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSystem
{
    class ATM
    {

        public int depositAmount = 0;                                                             
        public int withdrawAmount = 0;                                                            
        public int option;                                                                        
        List<User> Users = new List<User>();                                                       
        public void Init()
        {
            User anel = new("Anel", "1234", 5000);   //change user name and values
            User kuna = new("Kuna", "1111", 8000);   //change user name and values
            User sila = new("Sila", "5555", 7777);   //change user name and values
            User sela = new("Sela", "3333", 3000);   //change user name and values
            Users.Add(anel);
            Users.Add(kuna);
            Users.Add(sila);
            Users.Add(sela);
        }
        public void Execute()
        {
            User? loggedInUser = null;
            Console.Write("Enter Your ATM Pin: ");
            String ATMPIN = Console.ReadLine();                                                
            Console.Write("Enter Your Name :");
            String USERNAME = Console.ReadLine();
            loggedInUser = Users.Find(user => user.pin == ATMPIN && user.name == USERNAME);
            if (loggedInUser != null)
            {
                while (true)
                {
                    Console.WriteLine("Welcome " + loggedInUser.name + " to ATM Services" + " Your available balance is " + loggedInUser.balance);
                    Console.WriteLine("1. Cash Withdrawal");
                    Console.WriteLine("2. Deposit Money ");
                    Console.WriteLine("3. Exit");
                    Console.Write("Select option: ");
                    int option;
                    if (int.TryParse(Console.ReadLine(), out option))
                    {
                        option = (int)option;
                    }
                    else
                    {
                        Console.WriteLine("Your input is not valid");
                        //Environment.Exit(0);
                        Execute();
                    }
                    //option = int.Parse(Console.ReadLine());
                    switch (option)                                                                 
                    {
                        case 1:
                            CashWithdrawal();
                            break;
                        case 2:
                            CashDeposit();
                            break;
                        case 3:
                            Console.WriteLine("Goodbye and thanks for using out ATM service");
                            Execute();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("You've entered the wrong pin or user name");
                Execute();
            }


            void CashWithdrawal()
            {
                Console.Write("Enter withdrawal amount: ");
                withdrawAmount = int.Parse(Console.ReadLine());

                if (withdrawAmount % 100 != 0)
                {
                    Console.WriteLine("Please enter withdrawal amount in multiple of 100");
                    CashWithdrawal();
                }
                else if (withdrawAmount > loggedInUser.balance)
                {
                    Console.WriteLine("Insufficient balance in your account");
                    CashWithdrawal();
                }
                else
                {
                    loggedInUser.balance -= withdrawAmount;
                    Console.WriteLine("Please collect your money");
                    Console.WriteLine("Your remaining balance is: " + loggedInUser.balance);
                }
            }

            void CashDeposit()
            {
                Console.Write("Enter amount to deposit: ");
                depositAmount = int.Parse(Console.ReadLine());
                loggedInUser.balance += depositAmount;
                Console.WriteLine("Your current balance: " + loggedInUser.balance);
            }
        }
    }
}

public class User                                                                  
{
    public string name { get; set; }
    public string pin { get; set; }
    public int balance { get; set; }

    public User(String name, String pin, int balance)                       
    {
        this.name = name;
        this.pin = pin;
        this.balance = balance;
    }
}
