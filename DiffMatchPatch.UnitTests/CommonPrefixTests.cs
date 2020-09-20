using FluentAssertions;
using Xunit;

namespace DiffMatchPatch.UnitTests
{
    public class CommonPrefixTests
    {
        [Theory]
        [InlineData("abc", "xyz")]
        [InlineData("abcd", "xyz")]
        [InlineData("abc", "wxyz")]
        public void Given_different_strings_common_prefix_length_is_zero(string text1, string text2)
        {
            DiffTools.CommonPrefixLength(text1, text2).Should().Be(0);
        }        

        [Theory]
        [InlineData("abc")]
        [InlineData("abcd")]
        public void Given_identical_strings_common_prefix_length_is_length_of_whole_string(string input)
        {
            DiffTools.CommonPrefixLength(input, input).Should().Be(input.Length);
        }

        [Theory]
        [InlineData("123", "123foo", 3)]
        [InlineData("123bar", "123foo", 3)]
        [InlineData("12345", "12345foobar", 5)]
        [InlineData("12345baz", "12345foobar", 5)]
        public void Given_non_identical_strings_with_a_common_prefix_then_prefix_length_is_returned(string text1,
            string text2, int prefixLength)
        {
            DiffTools.CommonPrefixLength(text1, text2).Should().Be(prefixLength);
        }
    }
}