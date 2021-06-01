using Xunit;
using NumberInWordsToDecimalNumber;

namespace CodewarsTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("one", 1)]
        [InlineData("twenty", 20)]
        [InlineData("two hundred forty-six", 246)]
        [InlineData("two thousand", 2000)]
        [InlineData("seven hundred eighty-three thousand nine hundred and nineteen", 783919)]
        [InlineData(
            "one trillion three billion nine hundred eighty-seven million six hundred fifty-four thousand three hundred twenty-one",
            1003987654321)]
        public void Test1(string text, long value)
        {
            Assert.Equal(value, ParseInt.NumberInWordsToDecimalNumber(text));
        }
    }
}