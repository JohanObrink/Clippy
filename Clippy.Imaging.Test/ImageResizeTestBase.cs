using System;
using System.Drawing;

namespace Clippy.Imaging.Test
{
    public abstract class ImageResizeTestBase
    {
        protected Bitmap GenerateTestImage(int width, int height, Color? fill = null)
        {
            if (!fill.HasValue)
                fill = Color.Green;

            var bmp = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(fill.Value);
                g.Flush();
            }

            return bmp;
        }
    }
}
