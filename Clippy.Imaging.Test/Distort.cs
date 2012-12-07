using System;
using Xunit;
using FluentAssertions;

using Clippy.Imaging;

namespace Clippy.Imaging.Test
{
    public class Distort : ImageResizeTestBase
    {
        public void When_distorting_images_while_resizing_we_get_our_exact_requested_size()
        {
            var original = GenerateTestImage(800, 600);

            var image = new ResizeImage(original)
                .Distort()
                .ToSize(300, 300)
                .Save();

            image.Width.Should().Be(300);
            image.Height.Should().Be(300);
        }
    }
}
