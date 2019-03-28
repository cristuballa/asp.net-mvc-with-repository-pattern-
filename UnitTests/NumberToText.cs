using ApplicationCore.Services;
using System;
using Xunit;

namespace UnitTests
{
    public class NumberToTextTest
    {
        [Theory]
        [InlineData(0, "")]
        [InlineData(1, "ONE")]
        [InlineData(2, "TWO")]
        [InlineData(3, "THREE")]
        [InlineData(4, "FOUR")]
        [InlineData(5, "FIVE")]
        [InlineData(6, "SIX")]
        [InlineData(7, "SEVEN")]
        [InlineData(8, "EIGHT")]
        [InlineData(9, "NINE")]
        [InlineData(10, "TEN")]
        [InlineData(11, "ELEVEN")]
        [InlineData(12, "TWELVE")]
        [InlineData(13, "THIRTEEN")]
        [InlineData(14, "FOURTEEN")]
        [InlineData(15, "FIFTEEN")]
        [InlineData(16, "SIXTEEN")]
        [InlineData(17, "SEVENTEEN")]
        [InlineData(18, "EIGHTEEN")]
        [InlineData(19, "NINETEEN")]
        [InlineData(20, "TWENTY")]
        [InlineData(30, "THIRTY")]
        [InlineData(40, "FORTY")]
        [InlineData(50, "FIFTY")]
        [InlineData(60, "SIXTY")]
        [InlineData(70, "SEVENTY")]
        [InlineData(80, "EIGHTY")]
        [InlineData(90, "NINETY")]
        [InlineData(1000000000000.235, "ONE TRILLION AND TWENTY FOUR CENTS")]
        [InlineData(1000000000.235, "ONE BILLION AND TWENTY FOUR CENTS")]
        [InlineData(1000000, "ONE MILLION")]
        [InlineData(1000, "ONE THOUSAND")]
        [InlineData(12345, "TWELVE THOUSAND THREE HUNDRED FORTY FIVE")]
        [InlineData(6789, "SIX THOUSAND SEVEN HUNDRED EIGHTY NINE")] 
        [InlineData(1000000000000000000, "Invalid Amount.")] //More that 999 trillion 

        public void NumberToTextShouldPass(decimal Amount, string expected)
        {
            var numberToText = new NumberToText();

            numberToText.ConvertAmountToWord(Amount);
            string actual = numberToText.AmountInWords.Trim();

            Assert.Equal(expected,actual);

        }
    }
}
