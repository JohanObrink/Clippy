using System;
using Xunit;
using FluentAssertions;

using Clippy.Core;

namespace Clippy.Test.Core.NumberParsingExtensions
{
    public class ParseLongNullable
    {
        [Fact]
        public void It_parses_a_parseable_long()
        {
            "125".ParseLongNullable().Should().Be(125);
        }

        [Fact]
        public void It_parses_a_non_parseable_long()
        {
            "abc125".ParseLongNullable().HasValue.Should().BeFalse();
        }
    }
}
