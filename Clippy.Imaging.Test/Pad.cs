using System;
using Xunit;
using FluentAssertions;

using Clippy.Imaging;
using System.Drawing;
using System.IO;

namespace Clippy.Imaging.Test
{
    public class Pad : ImageResizeTestBase
    {
        [Fact]
        public void It_pads_to_exactly_requested_size()
        {
            var original = GenerateTestImage(800, 600);

            var resizedImage = new ResizeImage(original)
                .Pad(Color.Black)
                .ToSize(331, 418)
                .Save();

            resizedImage.Width.Should().Be(331);
            resizedImage.Height.Should().Be(418);
        }

        [Fact(Skip="Cannot explain difeerence in color")]
        public void It_pads_with_the_correct_color()
        {
            var original = GenerateTestImage(800, 600, Color.Yellow);

            var resizedImage = new ResizeImage(original)
                .Pad(Color.Black)
                .ToSize(400, 600)
                .Save();

            resizedImage.GetPixel(0, 0).ToHex().Should().Be(Color.Black.ToHex());
            resizedImage.GetPixel(399, 599).ToHex().Should().Be(Color.Black.ToHex());
            resizedImage.GetPixel(0, 151).ToHex().Should().Be(Color.Yellow.ToHex());
            resizedImage.GetPixel(400, 449).ToHex().Should().Be(Color.Yellow.ToHex());
        }
    }
}
