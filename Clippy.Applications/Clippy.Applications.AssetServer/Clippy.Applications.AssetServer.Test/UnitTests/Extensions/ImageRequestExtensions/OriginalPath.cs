using System;
using Clippy.Applications.AssetServer.Models;
using Clippy.Applications.AssetServer.Extensions;
using FluentAssertions;
using Xunit;
using Clippy.Applications.AssetServer.Infrastructure;

namespace Clippy.Applications.AssetServer.Test.UnitTests.Extensions.ImageRequestExtensions
{
    public class OriginalPath
    {
        [Fact]
        public void It_resolves_a_correct_original_path_for_original_image_in_root()
        {
            AssetServerConfiguration.MediaPath = () => @"c:\temp\";

            var imageData = new ImageRequestData
            {
                Id = "image",
                FileType = "png"
            };

            imageData.OriginalPath().Should().Be(@"c:\temp\image.png");
        }

        [Fact]
        public void It_resolves_a_correct_original_path_for_original_image_in_sub_folder()
        {
            AssetServerConfiguration.MediaPath = () => @"c:\temp\";

            var imageData = new ImageRequestData
            {
                Path = "/foo/bar",
                Id = "image",
                FileType = "png"
            };

            imageData.OriginalPath().Should().Be(@"c:\temp\foo\bar\image.png");
        }
    }
}
