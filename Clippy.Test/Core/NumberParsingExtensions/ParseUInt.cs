using System;
using Xunit;
using FluentAssertions;

using Clippy.Core;

namespace Clippy.Test.Core.NumberParsingExtensions
{
    public class ParseUInt
    {
        [Fact]
        public void It_parses_a_parseable_uint()
        {
            "125".ParseUInt().Should().Be((uint)125);
        }

        [Fact]
        public void It_parses_a_non_parseable_uint()
        {
            "abc125".ParseUInt().Should().Be((uint)0);
        }

        [Fact]
        public void It_parses_a_non_parseable_uint_with_fallback()
        {
            "abc125".ParseUInt(23).Should().Be((uint)23);
        }
    }
}
