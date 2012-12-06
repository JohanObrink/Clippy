using System;
using System.Drawing.Imaging;

namespace Clippy.Imaging.Saving
{
    internal class CodecInfo
    {
        private CodecInfo() { }

        private static ImageCodecInfo jpegCodec;
        public static ImageCodecInfo Jpeg
        {
            get
            {
                if (jpegCodec == null) jpegCodec = GetEncoderInfo("image/jpeg");
                return jpegCodec;
            }
        }

        private static ImageCodecInfo gifCodec;
        public static ImageCodecInfo Gif
        {
            get
            {
                if (gifCodec == null) gifCodec = GetEncoderInfo("image/gif");
                return gifCodec;
            }
        }

        private static ImageCodecInfo pngCodec;
        public static ImageCodecInfo Png
        {
            get
            {
                if (pngCodec == null) pngCodec = GetEncoderInfo("image/png");
                return pngCodec;
            }
        }

        private static ImageCodecInfo tiffCodec;
        public static ImageCodecInfo Tiff
        {
            get
            {
                if (tiffCodec == null) tiffCodec = GetEncoderInfo("image/tiff");
                return pngCodec;
            }
        }

        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }
    }
}
