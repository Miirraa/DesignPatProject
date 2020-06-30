using System;
using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class Tests
    {
        private const int LowRiskTaking = 2;
        private const double LoanAmount = 10000.00;
        private const double TwoDigitPrecision = 0.001;

        [Fact()]
        public void payment_is_constructed_correctly()
        {
            var christmasDay = new DateTime(2010, 12, 25);
            var payment = new Payment(1000.0, christmasDay);

            Assert.Equal(1000, payment.Amount);
            Assert.Equal(christmasDay, payment.Date);
        }

        [Fact()]
        public void test_term_loan_same_payments()
        {
            var start = November(20, 2003);

            Loan termLoan = new TermLoan(LoanAmount, start);
            termLoan.Payment(1000.00, November(20, 2004));
            termLoan.Payment(1000.00, November(20, 2005));
            termLoan.Payment(1000.00, November(20, 2006));

            Assert.Equal(20027, termLoan.Duration(), (int)TwoDigitPrecision);
            Assert.Equal(6008100, termLoan.Capital(), (int)TwoDigitPrecision);
        }

        [Fact()]
        public void test_revolver_loan_same_payments()
        {
            var start = November(20, 2003);
            var expiry = November(20, 2007);

            Loan revolverLoan = new RevolverLoan(LoanAmount, start, expiry);
            revolverLoan.Payment(1000.00, November(20, 2004));
            revolverLoan.Payment(1000.00, November(20, 2005));
            revolverLoan.Payment(1000.00, November(20, 2006));

            Assert.Equal(40027, revolverLoan.Duration(), (int)TwoDigitPrecision);
            Assert.Equal(4002700, revolverLoan.Capital(), (int)TwoDigitPrecision);
        }

        [Fact()]
        public void test_advised_line_loan_same_payments()
        {
            var start = November(20, 2003);
            var maturity = November(20, 2006);
            var expiry = November(20, 2007);

            Loan advisedLineLoan = new AdvisedLineLoan(LoanAmount, start, expiry, LowRiskTaking);
            advisedLineLoan.Payment(1000.00, November(20, 2004));
            advisedLineLoan.Payment(1000.00, November(20, 2005));
            advisedLineLoan.Payment(1000.00, November(20, 2006));

            Assert.Equal(40027, advisedLineLoan.Duration(), (int)TwoDigitPrecision);
            Assert.Equal(1200810, advisedLineLoan.Capital(), (int)TwoDigitPrecision);
        }

        private static DateTime November(int dayOfMonth, int year)
        {
            return new DateTime(year, 11, dayOfMonth);
        }
    }
}

