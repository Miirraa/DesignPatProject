using System;

namespace ESGI.DesignPattern.Projet
{
    public class AdvisedLineLoan : ExpiringLoan
    {
        private readonly double _unusedPercentage = 0.1;

        public AdvisedLineLoan(double commitment, DateTime start, DateTime expiry, int riskRating)
        {
            if (riskRating > 3)
                throw new Exception("Risk rating is too high for AdvisedLineLoan");

            Commitment = commitment;
            Start = start;
            Expiry = expiry;
        }
        
        public override double Capital()
        {
            return Commitment * _unusedPercentage * Duration() * RiskFactor;
        }

        public override double Duration()
        {
            return YearsTo(Expiry);
        }
    }
}