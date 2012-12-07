using System;
using System.Drawing;

namespace Clippy.Imaging.Resizing
{
    internal static class ResizerMath
    {
        internal static float AspectRatio(Size size)
        {
            return (float)((float)size.Width / (float)size.Height);
        }

        internal static RectangleF Rectangle(Size oldSize, Size newSize, ResizeMethod method)
        {
            return Rectangle(oldSize, newSize, method, 0.5f);
        }

        internal static RectangleF Rectangle(Size oldSize, Size newSize, ResizeMethod method, float cropOffset)
        {
            float scale;
            if (method.Equals(ResizeMethod.Crop))
            {
                scale = (AspectRatio(oldSize) > AspectRatio(newSize))
                        ? ((float)newSize.Height) / ((float)oldSize.Height)
                        : ((float)newSize.Width) / ((float)oldSize.Width);
            }
            else if (method.Equals(ResizeMethod.Pad) || method.Equals(ResizeMethod.Constrain))
            {
                scale = (AspectRatio(oldSize) < AspectRatio(newSize))
                        ? ((float)newSize.Height) / ((float)oldSize.Height)
                        : ((float)newSize.Width) / ((float)oldSize.Width);
            }
            else scale = 0;

            RectangleF rect = new RectangleF();

            switch (method)
            {
                case ResizeMethod.Constrain:
                    rect.Width = scale * (float)oldSize.Width;
                    rect.Height = scale * (float)oldSize.Height;
                    rect.X = 0;
                    rect.Y = 0;
                    break;
                case ResizeMethod.Crop:
                    cropOffset = Math.Max(0, Math.Min(1, cropOffset));
                    rect.Width = scale * (float)oldSize.Width;
                    rect.Height = scale * (float)oldSize.Height;
                    rect.X = -(float)Math.Round((rect.Width - newSize.Width) * cropOffset);
                    rect.Y = -(float)Math.Round((rect.Height - newSize.Height) * cropOffset);
                    break;
                case ResizeMethod.Distort:
                    rect.Width = (float)newSize.Width;
                    rect.Height = (float)newSize.Height;
                    rect.X = 0;
                    rect.Y = 0;
                    break;
                case ResizeMethod.Pad:
                    rect.Width = scale * (float)oldSize.Width;
                    rect.Height = scale * (float)oldSize.Height;
                    rect.X = -(float)Math.Round((rect.Width - newSize.Width) / 2);
                    rect.Y = -(float)Math.Round((rect.Height - newSize.Height) / 2);
                    break;
            }
            return rect;
        }
    }
}
