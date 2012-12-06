using System;
using Xunit;
using FluentAssertions;

using Clippy.Imaging;

namespace Clippy.Imaging.Test
{
    public class Crop : ImageResizeTestBase
    {
        [Fact]
        public void When_cropping_we_should_get_an_image_that_is_exactly_our_requested_size()
        {
            var original = GenerateTestImage(800, 600);

            var resized = new ResizeImage(original)
                .Crop()
                .ToSize(400, 300)
                .Save();

            resized.Width.Should().Be(400);
            resized.Height.Should().Be(300);
        }
    }
}
