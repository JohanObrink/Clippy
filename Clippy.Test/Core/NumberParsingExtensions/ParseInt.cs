using System;
using Xunit;
using FluentAssertions;

using Clippy.Core;

namespace Clippy.Test.Core.NumberParsingExtensions
{
    public class ParseInt
    {
        [Fact]
        public void It_parses_a_parseable_int()
        {
            "125".ParseInt().Should().Be(125);
        }

        [Fact]
        public void It_parses_a_non_parseable_int()
        {
            "abc125".ParseInt().Should().Be(0);
        }

        [Fact]
        public void It_parses_a_non_parseable_int_with_fallback()
        {
            "abc125".ParseInt(23).Should().Be(23);
        }
    }
}
