using System;
using System.Drawing;
using Xunit;
using FluentAssertions;

using Clippy.Imaging;

namespace Clippy.Imaging.Test
{
    public class Constrain : ImageResizeTestBase
    {
        [Fact]
        public void It_calculates_constrain_correctly()
        {
            var original = GenerateTestImage(800, 600);

            var resizedImage = new ResizeImage(original)
                .Constrain()
                .ToSize(200, 200)
                .Save();

            resizedImage.Width.Should().Be(200);
            resizedImage.Height.Should().Be(150);

            resizedImage = new ResizeImage(original)
                .Constrain()
                .ToSize(465, 250)
                .Save();

            resizedImage.Width.Should().Be(333);
            resizedImage.Height.Should().Be(250);
        }
    }
}
