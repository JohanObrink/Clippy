using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clippy.Applications.AssetServer.Test.Helpers
{
    public static class ImageExtensions
    {
        public static byte[] GetBytes(this Image image)
        {
            using(var stream = new MemoryStream()) {
                image.Save(stream, ImageFormat.Png);

                stream.Position = 0;
                var data = new byte[(int)stream.Length];
                stream.Read(data, 0, data.Length);

                return data;
            }
        }
    }
}
