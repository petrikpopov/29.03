using System;

namespace Chain_of_Responsibility_29._03._2023
{
    class Program
    {
        class Receiver
        {
            public bool Bank { get; set; }
            
            public bool Money { get; set; }
            
            public bool PayPal { get; set; }

            public Receiver(bool b, bool m, bool pp)
            {
                Bank = b;
                Money = m;
                PayPal = pp;
            }
        }
        abstract class Handler
        {
            public Handler handler { get; set; }

            public abstract void Handle(Receiver receiver);
        }

        class Bank : Handler
        {
            public override void Handle(Receiver receiver)
            {
                if (receiver.Bank == true)
                {
                    Console.WriteLine("Выполняем банковский перевод");
                }
                else 
                {
                    handler.Handle(receiver);
                }
            }
        }
        class Money : Handler
        {
            public override void Handle(Receiver receiver)
            {
                if (receiver.Money == true)
                {
                    Console.WriteLine("Все успешно");
                }
                else 
                {
                    handler.Handle(receiver);
                }
                  
            }
        }
        class PayPal : Handler
        {
            public override void Handle(Receiver receiver)
            {
                if (receiver.PayPal == true)
                {
                    Console.WriteLine("Выполняем перевод через PayPal");
                }
                else 
                {
                    handler.Handle(receiver);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Receiver receiver = new Receiver(false, false, true);

            Handler bank = new Bank();
            Handler money = new Money();
            Handler paypal = new PayPal();
            bank.handler = money;
            money.handler = paypal;

            money.Handle(receiver);




        }
    }
}
