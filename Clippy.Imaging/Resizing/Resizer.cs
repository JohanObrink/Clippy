using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Clippy.Imaging.Resizing
{
    /// <summary>
    /// Class that handles the resizing
    /// </summary>
    internal class Resizer
    {
        /// <summary>
        /// Method that resizes and returns a bitmap of the resized image
        /// depending on resizing method, size and padcolor
        /// </summary>
        /// <param name="image"></param>
        /// <param name="method"></param>
        /// <param name="size"></param>
        /// <param name="padColor"></param>
        /// <exception cref="T:ArgumentNullException">image</exception>
        /// <returns></returns>
        internal Bitmap Resize(Image image, ResizeMethod method, Size size, Color padColor)
        {
            var brush = new SolidBrush(padColor);
            return Resize(image, method, size, brush);
        }

        /// <summary>
        /// Method that resizes and returns a bitmap of the resized image
        /// depending on resizing method, size and padcolor
        /// </summary>
        /// <param name="image"></param>
        /// <param name="method"></param>
        /// <param name="size"></param>
        /// <param name="brush"></param>
        /// <returns></returns>
        internal Bitmap Resize(Image image, ResizeMethod method, Size size, Brush brush)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            var rect = ResizerMath.Rectangle(image.Size, size, method);
            var targetSize = (method == ResizeMethod.Constrain) ?
                new Size((int)rect.Width, (int)rect.Height) :
                size;

            var resizedImage = new Bitmap(targetSize.Width, targetSize.Height);
            using (var graphics = Graphics.FromImage(resizedImage))
            {
                if (method == ResizeMethod.Pad)
                    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, rect);
                graphics.Flush();
            }

            return resizedImage;
        }
    }
}
