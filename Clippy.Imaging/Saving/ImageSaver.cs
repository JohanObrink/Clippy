using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Clippy.Imaging.Saving
{
    /// <summary>
    /// Handles saving the the image
    /// </summary>
    internal class ImageSaver
    {
        /// <summary>
        /// Saves the image as a jpeg to the specified path
        /// </summary>
        /// <param name="image">the image</param>
        /// <param name="path">target path</param>
        /// <param name="quality">the quality of the jpeg 1 - 100</param>
        /// <param name="overwrite">whether any existing files should be overwritten</param>
        internal void SaveJpeg(Image image, string path, uint quality, bool overwrite)
        {
            ThrowExceptionIfFileExists(path, overwrite);

            using (var stream = File.Open(path, FileMode.Create))
            {
                SaveJpeg(image, stream, quality);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="stream"></param>
        /// <param name="quality"></param>
        internal void SaveJpeg(Image image, Stream stream, uint quality)
        {
            EncoderParameters parameters = new EncoderParameters()
            {
                Param = new[] { new EncoderParameter(Encoder.Quality, quality) }
            };
            image.Save(stream, CodecInfo.Jpeg, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="path"></param>
        /// <param name="overwrite"></param>
        internal void SavePng(Image image, string path, bool overwrite)
        {
            ThrowExceptionIfFileExists(path, overwrite);

            using (var stream = File.Open(path, FileMode.Create))
            {
                SavePng(image, stream);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="stream"></param>
        internal void SavePng(Image image, Stream stream)
        {
            image.Save(stream, ImageFormat.Png);
        }

        private void ThrowExceptionIfFileExists(string path, bool overwrite)
        {
            if (!overwrite && File.Exists(path))
                throw new ArgumentException("Cant save file to that path, since a file already exist there");
        }
    }
}
