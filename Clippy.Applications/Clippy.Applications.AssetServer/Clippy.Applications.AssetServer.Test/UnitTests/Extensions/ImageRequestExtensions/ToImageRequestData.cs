using System;
using Xunit;
using FluentAssertions;

using Clippy.Applications.AssetServer.Extensions;
using Configuration = Clippy.Applications.AssetServer.Infrastructure.AssetServerConfiguration;

namespace Clippy.Applications.AssetServer.Test.UnitTests.Extensions.ImageRequestExtensions
{
    public class ToImageRequestData
    {
        [Fact]
        public void It_parses_groups_correctly()
        {
            var requestData =
                Configuration.ImageDataRegex.Match("/foo/bar/400x300/image_darkside(45).jpg")
                .ToImageRequestData();
            
            requestData.Path.Should().Be("/foo/bar");
            requestData.Height.Should().Be(300);
            requestData.Width.Should().Be(400);
            requestData.Id.Should().Be("image");
            requestData.Variant.Should().Be("darkside");
            requestData.JpegQuality.Should().Be(45);
            requestData.FileType.Should().Be("jpg");
        }
    }
}
