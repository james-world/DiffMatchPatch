using FluentAssertions;
using Xunit;

namespace DiffMatchPatch.UnitTests
{
    public class CommonSuffixTests
    {
        [Theory]
        [InlineData("abc", "xyz")]
        [InlineData("abcd", "xyz")]
        [InlineData("abc", "wxyz")]
        public void Given_different_strings_common_suffix_length_is_zero(string text1, string text2)
        {
            var sut = new DiffMatchPatch();
            sut.DiffCommonSuffix(text1, text2).Should().Be(0);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("abcd")]
        public void Given_identical_strings_common_suffix_length_is_length_of_whole_string(string input)
        {
            var sut = new DiffMatchPatch();
            sut.DiffCommonSuffix(input, input).Should().Be(input.Length);
        }

        [Theory]
        [InlineData("bar123", "foo123", 3)]
        [InlineData("foobar12345", "foo12345", 5)]
        public void Given_non_identical_strings_with_a_common_suffix_then_prefix_length_is_returned(string text1,
            string text2, int suffixLength)
        {
            var sut = new DiffMatchPatch();
            sut.DiffCommonSuffix(text1, text2).Should().Be(suffixLength);
        }
    }
}