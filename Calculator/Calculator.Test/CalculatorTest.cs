using Xunit;

namespace Calculator.ReversePolistNotationTest
{
    public class CalculatorTest
    {
        [Fact]
        public void ResultOfCalculate()
        {
            Calculator calculator = new Calculator();
            
            var input = "1+2+3+4+5";
            decimal expected = 15;
            
            var actual = calculator.Calculate(input);
            Assert.Equal(expected,actual);

            var input2 = "2*3-1*4*(16/4)+5";
            decimal expected2 = -5;
            var actual2 = calculator.Calculate(input2);
            Assert.Equal(expected2,actual2);

            var input3 = "2.342*3.1-2.33*(15/6)-1.32";
            decimal expected3 = 0.1152M;
            var actual3 = calculator.Calculate(input3);
            Assert.Equal(expected3,actual3);
        }
    }
}