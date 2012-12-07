using System;
using Xunit;
using FluentAssertions;

using Clippy.Core;

namespace Clippy.Test.Core.NumberParsingExtensions
{
    public class ParseLong
    {
        [Fact]
        public void It_parses_a_parseable_long()
        {
            "125".ParseLong().Should().Be(125);
        }

        [Fact]
        public void It_parses_a_non_parseable_long()
        {
            "abc125".ParseLong().Should().Be(0);
        }

        [Fact]
        public void It_parses_a_non_parseable_long_with_fallback()
        {
            "abc125".ParseLong(23).Should().Be(23);
        }
    }
}
