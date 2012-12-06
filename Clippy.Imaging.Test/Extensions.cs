using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Clippy.Imaging.Test
{
    public static class Extensions
    {
        public static string ToHex(this Color color)
        {
            return color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }
    }
}
