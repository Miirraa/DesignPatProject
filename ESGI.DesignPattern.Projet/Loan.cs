using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public abstract class Loan
    {
        protected IList<Payment> Payments { get; } = new List<Payment>();
        
        protected double Commitment { get; set; }

        protected DateTime Start { get; set; }

        protected const double RiskFactor = 0.03;
        protected const double UnusedRiskFactor = 0.01;
        
        private const long MillisPerDay = 86400000;
        private const long DaysPerYear = 365;

        public void Payment(double amount, DateTime paymentDate)
        {
            Payments.Add(new Payment(amount, paymentDate));
        }

        public abstract double Capital();

        public abstract double Duration();
        
        protected double YearsTo(DateTime endDate)
        {
            return ((double)(endDate.Ticks - Start.Ticks)) / MillisPerDay / DaysPerYear;
        }
    }
}
