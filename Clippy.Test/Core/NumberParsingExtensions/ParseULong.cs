using System;
using Xunit;
using FluentAssertions;

using Clippy.Core;

namespace Clippy.Test.Core.NumberParsingExtensions
{
    public class ParseULong
    {
        [Fact]
        public void It_parses_a_parseable_ulong()
        {
            "125".ParseULong().Should().Be((ulong)125);
        }

        [Fact]
        public void It_parses_a_non_parseable_ulong()
        {
            "abc125".ParseULong().Should().Be((ulong)0);
        }

        [Fact]
        public void It_parses_a_non_parseable_ulong_with_fallback()
        {
            "abc125".ParseULong(23).Should().Be((ulong)23);
        }
    }
}
