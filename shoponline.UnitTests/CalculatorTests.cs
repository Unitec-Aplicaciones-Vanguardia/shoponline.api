using System;
using Xunit;

namespace shoponline.UnitTests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(6, 10)]
        [InlineData(7, 5)]
        [InlineData(8, 3)]
        [InlineData(9, 1)]
        public void Add_TwoValidNumbers_Succeeds(int num1, int num2)
        {
            var calculator = new Calculator();
            var sum = calculator.Add(num1, num2);
            Assert.True(sum == num1+num2);
            Assert.Equal(num1+num2, sum);
        }

        [Theory]
        [InlineData(6, 10)]
        [InlineData(7, 5)]
        public void Divide_TwoValidNumbers_Succeeds(double num1, double num2)
        {
            var calculator = new Calculator();
            var result = calculator.Divide(num1, num2);
            Assert.Equal(num1 / num2, result);
        }

        [Theory]
        [InlineData(6)]
        public void Divide_ByZero_Fails(double num1)
        {
            var calculator = new Calculator();
            Assert.ThrowsAny<ArgumentException>(() => calculator.Divide(num1, 0));
        }
    }
}
