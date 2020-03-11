using System;

namespace TDDBank
{
    //- Kontostand abfragen
    //- Betrag einzahlen(nicht Negativ)
    //- Betrag abheben(nicht Negativ)
    //	- Darf nicht unter 0 fallen
    //- Neues Konto hat 0 als Kontostand
    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public void Deposit(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException();
            Balance += value;
        }

        public void Withdraw(decimal value)
        {
            if (value > Balance)
                throw new InvalidOperationException();

            if (value <= 0)
                throw new ArgumentException();
            Balance -= value;
        }
    }
}
