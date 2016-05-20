using Xunit;

namespace Calculator.Tests
{
    public class StringCalculatorTests
    {
        private readonly StringCalculator _stringCalculator;

        public StringCalculatorTests()
        {
            _stringCalculator = new StringCalculator();
        }

        [Fact]
        public void Add_WhenPassEmptyString_InstanceHasValues()
        {
            // arrange
            var sum = _stringCalculator.Add("");

            // assert
            Assert.Equal(0, sum);
        }

        [Fact]
        public void Add_WhenPassNumbers_InstanceHasValues()
        {
            // arrange
            var sum = _stringCalculator.Add("1,2,3,4,5,6");

            // assert
            Assert.Equal(21, sum);
        }  

    }
}
