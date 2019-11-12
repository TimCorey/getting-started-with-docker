using SampleWebApp;
using System;
using Xunit;

namespace TestProj
{
    public class CalculationTests
    {
        [Theory]
        [InlineData(12, 3, 4)]
        [InlineData(15, 3, 5)]
        [InlineData(21, 3, 7)]
        [InlineData(36, 9, 4)]
        //[InlineData(36, 0, 0)]
        public void Divide_ShouldWork(double x, double y, double expected)
        {
            double actual = Calculation.Divide(x, y);

            Assert.Equal(expected, actual);
        }
    }
}
