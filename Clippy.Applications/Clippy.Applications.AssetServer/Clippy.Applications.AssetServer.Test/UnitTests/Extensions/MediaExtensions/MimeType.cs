using System;
using Xunit;
using FluentAssertions;

using Clippy.Applications.AssetServer.Extensions;

namespace Clippy.Applications.AssetServer.Test.UnitTests.Extensions.MediaExtensions
{
    public class MimeType
    {
        [Fact]
        public void It_finds_the_correct_mime_type()
        {
            "/foo/bar/baz.png?query=string".MimeType().Should().Be("image/png");
        }
    }
}
