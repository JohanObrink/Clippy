using System;
using Xunit;
using FluentAssertions;

using Configuration = Clippy.Applications.AssetServer.Infrastructure.AssetServerConfiguration;

namespace Clippy.Applications.AssetServer.Test.UnitTests.Infrastructure.AssetServerConfiguration
{
    public class ImageDataRegex
    {
        [Fact]
        public void It_finds_an_original_image_in_the_root()
        {
            var imageData = Configuration.ImageDataRegex.Match("/image.png");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("");
            imageData.Groups["width"].Value.Should().BeEmpty();
            imageData.Groups["height"].Value.Should().BeEmpty();
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().BeEmpty();
            imageData.Groups["quality"].Value.Should().BeEmpty();
            imageData.Groups["filetype"].Value.Should().Be("png");
        }

        [Fact]
        public void It_finds_an_original_image_in_a_sub_directory()
        {
            var imageData = Configuration.ImageDataRegex.Match("/foo/image.png");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("/foo");
            imageData.Groups["width"].Value.Should().BeEmpty();
            imageData.Groups["height"].Value.Should().BeEmpty();
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().BeEmpty();
            imageData.Groups["quality"].Value.Should().BeEmpty();
            imageData.Groups["filetype"].Value.Should().Be("png");
        }

        [Fact]
        public void It_finds_an_image_variant_in_the_root()
        {
            var imageData = Configuration.ImageDataRegex.Match("/image__darkside.png");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("");
            imageData.Groups["width"].Value.Should().BeEmpty();
            imageData.Groups["height"].Value.Should().BeEmpty();
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().Be("darkside");
            imageData.Groups["quality"].Value.Should().BeEmpty();
            imageData.Groups["filetype"].Value.Should().Be("png");
        }

        [Fact]
        public void It_finds_an_image_variant_in_a_sub_directory()
        {
            var imageData = Configuration.ImageDataRegex.Match("/foo/image__darkside.png");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("/foo");
            imageData.Groups["width"].Value.Should().BeEmpty();
            imageData.Groups["height"].Value.Should().BeEmpty();
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().Be("darkside");
            imageData.Groups["quality"].Value.Should().BeEmpty();
            imageData.Groups["filetype"].Value.Should().Be("png");
        }

        [Fact]
        public void It_finds_a_scaled_image_in_the_root()
        {
            var imageData = Configuration.ImageDataRegex.Match("/400x300/image.png");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("");
            imageData.Groups["width"].Value.Should().Be("400");
            imageData.Groups["height"].Value.Should().Be("300");
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().BeEmpty();
            imageData.Groups["quality"].Value.Should().BeEmpty();
            imageData.Groups["filetype"].Value.Should().Be("png");
        }

        [Fact]
        public void It_finds_a_scaled_image_in_a_sub_directory()
        {
            var imageData = Configuration.ImageDataRegex.Match("/foo/400x300/image.png");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("/foo");
            imageData.Groups["width"].Value.Should().Be("400");
            imageData.Groups["height"].Value.Should().Be("300");
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().BeEmpty();
            imageData.Groups["quality"].Value.Should().BeEmpty();
            imageData.Groups["filetype"].Value.Should().Be("png");
        }
    }
}
