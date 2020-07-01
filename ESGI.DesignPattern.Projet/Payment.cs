using System;
using System.Collections.Generic;
using System.Text;

namespace ESGI.DesignPattern.Projet
{
    public class Payment
    {
        public Payment(double amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }

        public double Amount { get; private set; }

        public DateTime Date { get; private set; }
    }
}
