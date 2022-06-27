using ATMSystem;
class ATMProgram
{
    static void Main()
    {
        ATM atm = new ATM();
        atm.Init();
        atm.Execute();
    }
}
