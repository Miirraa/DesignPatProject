using System;

namespace ESGI.DesignPattern.Projet
{
    public abstract class ExpiringLoan : Loan
    {
        protected DateTime Expiry { get; set; }
    }
}