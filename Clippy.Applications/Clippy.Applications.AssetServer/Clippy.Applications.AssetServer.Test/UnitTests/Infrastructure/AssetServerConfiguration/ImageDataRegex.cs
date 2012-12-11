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


        [Fact]
        public void It_finds_a_scaled_image_variant_in_the_root()
        {
            var imageData = Configuration.ImageDataRegex.Match("/400x300/image__darkside.png");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("");
            imageData.Groups["width"].Value.Should().Be("400");
            imageData.Groups["height"].Value.Should().Be("300");
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().Be("darkside");
            imageData.Groups["quality"].Value.Should().BeEmpty();
            imageData.Groups["filetype"].Value.Should().Be("png");
        }

        [Fact]
        public void It_finds_a_scaled_image_variant_in_a_sub_directory()
        {
            var imageData = Configuration.ImageDataRegex.Match("/foo/400x300/image__darkside.png");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("/foo");
            imageData.Groups["width"].Value.Should().Be("400");
            imageData.Groups["height"].Value.Should().Be("300");
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().Be("darkside");
            imageData.Groups["quality"].Value.Should().BeEmpty();
            imageData.Groups["filetype"].Value.Should().Be("png");
        }

        [Fact]
        public void It_finds_a_jpeg_image_in_the_root()
        {
            var imageData = Configuration.ImageDataRegex.Match("/image.jpg");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("");
            imageData.Groups["width"].Value.Should().BeEmpty();
            imageData.Groups["height"].Value.Should().BeEmpty();
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().BeEmpty();
            imageData.Groups["quality"].Value.Should().BeEmpty();
            imageData.Groups["filetype"].Value.Should().Be("jpg");
        }

        [Fact]
        public void It_finds_a_jpeg_image_in_a_sub_directory()
        {
            var imageData = Configuration.ImageDataRegex.Match("/foo/image.jpg");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("/foo");
            imageData.Groups["width"].Value.Should().BeEmpty();
            imageData.Groups["height"].Value.Should().BeEmpty();
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().BeEmpty();
            imageData.Groups["quality"].Value.Should().BeEmpty();
            imageData.Groups["filetype"].Value.Should().Be("jpg");
        }

        [Fact]
        public void It_finds_a_jpeg_image_with_quality_in_the_root()
        {
            var imageData = Configuration.ImageDataRegex.Match("/image(40).jpg");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("");
            imageData.Groups["width"].Value.Should().BeEmpty();
            imageData.Groups["height"].Value.Should().BeEmpty();
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().BeEmpty();
            imageData.Groups["quality"].Value.Should().Be("40");
            imageData.Groups["filetype"].Value.Should().Be("jpg");
        }

        [Fact]
        public void It_finds_a_jpeg_image_with_quality_in_a_sub_directory()
        {
            var imageData = Configuration.ImageDataRegex.Match("/foo/image(40).jpg");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("/foo");
            imageData.Groups["width"].Value.Should().BeEmpty();
            imageData.Groups["height"].Value.Should().BeEmpty();
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().BeEmpty();
            imageData.Groups["quality"].Value.Should().Be("40");
            imageData.Groups["filetype"].Value.Should().Be("jpg");
        }

        [Fact]
        public void It_finds_a_scaled_jpeg_image_with_quality_in_the_root()
        {
            var imageData = Configuration.ImageDataRegex.Match("/300x400/image(40).jpg");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("");
            imageData.Groups["width"].Value.Should().Be("300");
            imageData.Groups["height"].Value.Should().Be("400");
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().BeEmpty();
            imageData.Groups["quality"].Value.Should().Be("40");
            imageData.Groups["filetype"].Value.Should().Be("jpg");
        }

        [Fact]
        public void It_finds_a_scaled_jpeg_image_with_quality_in_a_sub_directory()
        {
            var imageData = Configuration.ImageDataRegex.Match("/foo/300x400/image(40).jpg");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("/foo");
            imageData.Groups["width"].Value.Should().Be("300");
            imageData.Groups["height"].Value.Should().Be("400");
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().BeEmpty();
            imageData.Groups["quality"].Value.Should().Be("40");
            imageData.Groups["filetype"].Value.Should().Be("jpg");
        }

        [Fact]
        public void It_finds_a_jpeg_image_variant_with_quality_in_the_root()
        {
            var imageData = Configuration.ImageDataRegex.Match("/image__darkside(40).jpg");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("");
            imageData.Groups["width"].Value.Should().BeEmpty();
            imageData.Groups["height"].Value.Should().BeEmpty();
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().Be("darkside");
            imageData.Groups["quality"].Value.Should().Be("40");
            imageData.Groups["filetype"].Value.Should().Be("jpg");
        }

        [Fact]
        public void It_finds_a_jpeg_image_variant_with_quality_in_a_sub_directory()
        {
            var imageData = Configuration.ImageDataRegex.Match("/foo/image__darkside(40).jpg");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("/foo");
            imageData.Groups["width"].Value.Should().BeEmpty();
            imageData.Groups["height"].Value.Should().BeEmpty();
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().Be("darkside");
            imageData.Groups["quality"].Value.Should().Be("40");
            imageData.Groups["filetype"].Value.Should().Be("jpg");
        }

        [Fact]
        public void It_finds_a_scaled_jpeg_image_variant_with_quality_in_the_root()
        {
            var imageData = Configuration.ImageDataRegex.Match("/300x400/image__darkside(40).jpg");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("");
            imageData.Groups["width"].Value.Should().Be("300");
            imageData.Groups["height"].Value.Should().Be("400");
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().Be("darkside");
            imageData.Groups["quality"].Value.Should().Be("40");
            imageData.Groups["filetype"].Value.Should().Be("jpg");
        }

        [Fact]
        public void It_finds_a_scaled_jpeg_image_variant_with_quality_in_a_sub_directory()
        {
            var imageData = Configuration.ImageDataRegex.Match("/foo/300x400/image__darkside(40).jpg");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("/foo");
            imageData.Groups["width"].Value.Should().Be("300");
            imageData.Groups["height"].Value.Should().Be("400");
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().Be("darkside");
            imageData.Groups["quality"].Value.Should().Be("40");
            imageData.Groups["filetype"].Value.Should().Be("jpg");
        }

        [Fact]
        public void It_finds_a_scaled_jpeg_image_variant_with_quality_in_a_sub_sub_directory()
        {
            var imageData = Configuration.ImageDataRegex.Match("/foo/bar/300x400/image__darkside(40).jpg");

            imageData.Success.Should().BeTrue();
            imageData.Groups["path"].Value.Should().Be("/foo/bar");
            imageData.Groups["width"].Value.Should().Be("300");
            imageData.Groups["height"].Value.Should().Be("400");
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().Be("darkside");
            imageData.Groups["quality"].Value.Should().Be("40");
            imageData.Groups["filetype"].Value.Should().Be("jpg");
        }

        [Fact]
        public void It_returns_false_for_malformed_url()
        {
            var imageData = Configuration.ImageDataRegex.Match("../foo/bar/300x400/image__darkside(40).jpg");

            imageData.Success.Should().BeFalse();
        }
    }
}
