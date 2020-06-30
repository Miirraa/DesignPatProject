using System;
using System.Collections.ObjectModel;

namespace ESGI.DesignPattern.Projet
{
    public class AdvisedLineLoan : ExpiringLoan
    {
        private const double UnusedPercentage = 0.1;

        private const int MaxAcceptableRiskRating = 3;

        public AdvisedLineLoan(double commitment, DateTime start, DateTime expiry, int riskRating)
        {
            if (riskRating > MaxAcceptableRiskRating)
                throw new Exception("Risk rating is too high for AdvisedLineLoan");

            Commitment = commitment;
            Start = start;
            Expiry = expiry;
        }
        
        public override double Capital()
        {
            return Commitment * UnusedPercentage * Duration() * RiskFactor;
        }

        public override double Duration()
        {
            return YearsTo(Expiry);
        }
    }
}