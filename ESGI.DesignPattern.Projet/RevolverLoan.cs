using System;

namespace ESGI.DesignPattern.Projet
{
    public class RevolverLoan : ExpiringLoan
    {
        private double Outstanding { get; set; }
        
        private const double UnusedRiskFactor = 0.01;

        public RevolverLoan(double commitment, DateTime start, DateTime expiry, double outstanding = 0.00)
        {
            Commitment = commitment;
            Start = start;
            Expiry = expiry;
            Outstanding = outstanding;
        }
        
        public override double Capital()
        {
            return (Outstanding * Duration() * RiskFactor)
                   + (UnusedRiskAmount() * Duration() * UnusedRiskFactor);
        }

        public override double Duration()
        {
            return YearsTo(Expiry);
        }

        private double UnusedRiskAmount()
        {
            return (Commitment - Outstanding);
        }
    }
}