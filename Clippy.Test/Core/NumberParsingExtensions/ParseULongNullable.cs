using System;
using Xunit;
using FluentAssertions;

using Clippy.Core;

namespace Clippy.Test.Core.NumberParsingExtensions
{
    public class ParseULongNullable
    {
        [Fact]
        public void It_parses_a_parseable_ulong()
        {
            "125".ParseULongNullable().Should().Be((ulong)125);
        }

        [Fact]
        public void It_parses_a_non_parseable_ulong()
        {
            "abc125".ParseULongNullable().HasValue.Should().BeFalse();
        }
    }
}
