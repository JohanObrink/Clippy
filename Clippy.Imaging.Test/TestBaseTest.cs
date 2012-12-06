using System;
using Xunit;
using FluentAssertions;
using System.Drawing;

namespace Clippy.Imaging.Test
{
    public class TestBaseTest : ImageResizeTestBase
    {
        [Fact]
        public void It_generates_a_test_image_of_the_correct_size()
        {
            var test = GenerateTestImage(400, 300);

            test.Width.Should().Be(400);
            test.Height.Should().Be(300);
        }

        [Fact]
        public void It_fills_the_test_image_as_expected()
        {
            var test = GenerateTestImage(400, 300, Color.Yellow);

            test.GetPixel(0, 0).ToArgb().Should().Be(Color.Yellow.ToArgb());
            test.GetPixel(399, 299).ToArgb().Should().Be(Color.Yellow.ToArgb());
        }
    }
}
