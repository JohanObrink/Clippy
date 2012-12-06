using System;
using Xunit;
using FluentAssertions;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Clippy.Imaging.Test
{
    public class Save : ImageResizeTestBase
    {
        private Bitmap theImage;

        public Save()
        {
            theImage = GenerateTestImage(800, 600);
        }

        [Fact]
        public void It_can_save_jpeg_from_memory_image()
        {
            var targetPath = GetImagePath("image.jpg");

            new ResizeImage(theImage)
                .Constrain()
                .ToSize(300, 300)
                .SaveJpeg(targetPath);

            using (var image = Image.FromFile(targetPath))
            {
                image.Should().NotBeNull();
                image.RawFormat.Should().Be(ImageFormat.Jpeg);
            }

            File.Delete(targetPath);
        }

        [Fact]
        public void It_can_save_png_from_memory_image()
        {
            var targetPath = GetImagePath("image.png");

            new ResizeImage(theImage)
                .Constrain()
                .ToSize(300, 300)
                .SavePng(targetPath);

            using (var image = Image.FromFile(targetPath))
            {
                image.Should().NotBeNull();
                image.RawFormat.Should().Be(ImageFormat.Png);
            }

            File.Delete(targetPath);
        }

        [Fact]
        public void It_can_save_png_from_image_on_disk()
        {
            var demoImage = GetImagePath("Assets/koala.jpg");
            var targetPath = GetImagePath("koala.png");

            new ResizeImage(demoImage)
                .Constrain()
                .ToSize(300, 300)
                .SavePng(targetPath);

            using (var image = Image.FromFile(targetPath))
            {
                image.Should().NotBeNull();
                image.RawFormat.Should().Be(ImageFormat.Png);
            }

            File.Delete(targetPath);
        }

        [Fact]
        public void It_can_overwrite_existing_image()
        {
            var targetPath = GetImagePath("Assets/image.png");

            new ResizeImage(theImage)
                .Constrain()
                .ToSize(300, 300)
                .SavePng(targetPath);

            new ResizeImage(theImage)
                .Constrain()
                .ToSize(500, 200)
                .SavePng(path: targetPath, overwrite: true);

            File.Delete(targetPath);
        }

        [Fact]
        public void When_lowering_quality_the_image_should_become_smaller()
        {
            var image1 = GetImagePath("image1.jpg");
            var image2 = GetImagePath("image2.jpg");

            var demoImage = GetImagePath("Assets/koala.jpg");

            new ResizeImage(demoImage)
                .Constrain()
                .ToSize(300, 300)
                .SaveJpeg(image1, 80);

            new ResizeImage(demoImage)
                .Constrain()
                .ToSize(300, 300)
                .SaveJpeg(image2, 40);

            using (var higherQuality = File.OpenRead(image1))
            {
                using (var lowerQuality = File.OpenRead(image2))
                {
                    higherQuality.Length.Should().BeGreaterThan(lowerQuality.Length);
                }
            }

            File.Delete(image1);
            File.Delete(image2);
        }

        private string GetImagePath(string fileName)
        {
            var targetPath = Path.GetFullPath("./" + fileName);
            return targetPath;
        }
    }
}
