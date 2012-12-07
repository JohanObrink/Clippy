using System;
using Xunit;
using FluentAssertions;

using Clippy.Core;

namespace Clippy.Test.Core.NumberParsingExtensions
{
    public class ParseIntNullable
    {
        [Fact]
        public void It_parses_a_parseable_int()
        {
            "125".ParseIntNullable().Should().Be(125);
        }

        [Fact]
        public void It_parses_a_non_parseable_int()
        {
            "abc125".ParseIntNullable().HasValue.Should().BeFalse();
        }
    }
}
