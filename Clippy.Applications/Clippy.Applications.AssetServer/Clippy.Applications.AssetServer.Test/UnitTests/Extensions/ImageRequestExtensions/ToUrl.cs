using System;
using Xunit;
using FluentAssertions;

using Clippy.Applications.AssetServer.Extensions;
using Clippy.Applications.AssetServer.Models;

namespace Clippy.Applications.AssetServer.Test.UnitTests.Extensions.ImageRequestExtensions
{
    public class ToUrl
    {
        [Fact]
        public void It_converts_only_id_to_correct_url()
        {
            var data = new ImageRequestData
            {
                Id = "image",
                FileType = "png"
            };
            data.ToUrl().Should().Be("/image.png");
        }

        [Fact]
        public void It_converts_id_and_path_to_correct_url()
        {
            var data = new ImageRequestData
            {
                Path = "/foo/bar",
                Id = "image",
                FileType = "png"
            };
            data.ToUrl().Should().Be("/foo/bar/image.png");
        }

        [Fact]
        public void It_converts_id_path_and_size_to_correct_url()
        {
            var data = new ImageRequestData
            {
                Path = "/foo/bar",
                Id = "image",
                FileType = "png",
                Width = 400,
                Height = 300
            };
            data.ToUrl().Should().Be("/foo/bar/400x300/image.png");
        }

        [Fact]
        public void It_converts_id_path_size_and_variant_to_correct_url()
        {
            var data = new ImageRequestData
            {
                Path = "/foo/bar",
                Id = "image",
                FileType = "png",
                Width = 400,
                Height = 300,
                Variant = "darkside"
            };
            data.ToUrl().Should().Be("/foo/bar/400x300/image__darkside.png");
        }

        [Fact]
        public void It_converts_id_path_size_variant_and_quality_to_correct_url()
        {
            var data = new ImageRequestData
            {
                Path = "/foo/bar",
                Id = "image",
                FileType = "jpg",
                Width = 400,
                Height = 300,
                Variant = "darkside",
                JpegQuality = 55
            };
            data.ToUrl().Should().Be("/foo/bar/400x300/image__darkside(55).jpg");
        }
    }
}
