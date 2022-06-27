using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSystem
{
    class ATM
    {

        public int depositAmount = 0;                                                             //int - cijela vrijednost  depositAmount
        public int withdrawAmount = 0;                                                            //int - cijela vrijednost withdrawamounta
        public int option;                                                                        //int - vrijednost izbora iz "Menu-a"
        List<User> Users = new List<User>();                                                      //Deklarisanje nove liste User-a 
        public void Init()
        {
            User anel = new("Anel", "1234", 5000);
            User kuna = new("Kuna", "1111", 8000);
            User sila = new("Sila", "5555", 7777);
            User sela = new("Sela", "3333", 3000);
            Users.Add(anel);
            Users.Add(kuna);
            Users.Add(sila);
            Users.Add(sela);
        }
        public void Execute()
        {
            User? loggedInUser = null;
            Console.Write("Enter Your ATM Pin: ");
            String ATMPIN = Console.ReadLine();                                                // deklarisanje unesenog pina kao string "ATMPIN"
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
                    switch (option)                                                                 //Moze se koristiti kao zamjena za if, else if, else gdje ostavljamo caseove
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

public class User                                                                  // definisana class-a User
{
    public string name { get; set; }
    public string pin { get; set; }
    public int balance { get; set; }

    public User(String name, String pin, int balance)                       // konstruktor class-e User
    {
        this.name = name;
        this.pin = pin;
        this.balance = balance;
    }
}
