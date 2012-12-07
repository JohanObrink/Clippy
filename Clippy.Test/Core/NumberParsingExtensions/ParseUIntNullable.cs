using System;
using Xunit;
using FluentAssertions;

using Clippy.Core;

namespace Clippy.Test.Core.NumberParsingExtensions
{
    public class ParseUIntNullable
    {
        [Fact]
        public void It_parses_a_parseable_uint()
        {
            "125".ParseUIntNullable().Should().Be((uint)125);
        }

        [Fact]
        public void It_parses_a_non_parseable_uint()
        {
            "abc125".ParseUIntNullable().HasValue.Should().BeFalse();
        }
    }
}
