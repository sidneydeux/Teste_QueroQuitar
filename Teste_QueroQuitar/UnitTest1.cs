using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_QueroQuitar
{
    [TestClass]
    public class UnitTestQueroQuitar
    {
        [TestMethod]
        public void VerifyConvertYearlyFee()
        {
            var monthlyFee = ConvertYearlyFeeToMonthlyFee(0.26824);
            Assert.AreEqual(0.02, monthlyFee);
        }

        [TestMethod]
        public void CalculatePresentValueByMonth()
        {
            var presentValue = PresentValueByMonth(1902.36269, 0.02, 12);
            Assert.AreEqual(1500, presentValue);
        }

        [TestMethod]
        public void CalculatePresentValueByYear()
        {
            var presentValue = PresentValueByYear(1902.36269, 0.26824, 12);
            Assert.AreEqual(1500, presentValue);
        }

        [TestMethod]
        public void ComparePresentValueByMonthToPresentValueByYear()
        {
            var presentValueByMonth = PresentValueByMonth(1902.36269, 0.02, 12);
            var presentValueByYear = PresentValueByYear(1902.36269, 0.26824, 12);
            Assert.AreEqual(presentValueByMonth, presentValueByYear);
        }

        public double PresentValueByMonth(double futureValue, double monthlyFee, int plots)
        {
            var presentValue = futureValue / Math.Pow((1 + monthlyFee), plots);
            return Math.Round(presentValue, 2);
        }

        public double PresentValueByYear(double futureValue, double yearlyFee, int plots)
        {
            var monthlyFee = ConvertYearlyFeeToMonthlyFee(yearlyFee);
            var presentValue = futureValue / Math.Pow((1 + monthlyFee), plots);
            return Math.Round(presentValue, 5);
        }
        public double ConvertYearlyFeeToMonthlyFee(double yearlyFee)
        {
            var monthlyFee = Math.Pow((1 + yearlyFee), 0.08333)-1;
            return Math.Round(monthlyFee, 5);
        }
    }

}
