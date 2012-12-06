using System;
using System.Drawing;
using System.IO;

using Clippy.Imaging.Resizing;
using Clippy.Imaging.Saving;

namespace Clippy.Imaging
{
    /// <summary>
    /// Class that enables resizing of images
    /// </summary>
    public class ResizeImage : IDisposable
    {
        private Image originalImage;

        /// <summary>
        /// Initialize a new Image Resize from a location on disk
        /// </summary>
        /// <param name="filePath"></param>
        /// <exception cref="T:ArgumentNullException">filePath</exception>
        /// <exception cref="T:FileNotFoundException">filePath</exception>
        public ResizeImage(string filePath)
            : this()
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException("filePath");

            if (!File.Exists(filePath))
                throw new FileNotFoundException(string.Format("No file found at '{0}'", filePath));

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                originalImage = Bitmap.FromStream(stream);
            }
        }

        /// <summary>
        /// Initiates a new Resize from a stream
        /// </summary>
        /// <param name="fileStream"></param>
        public ResizeImage(Stream fileStream)
            : this()
        {
            if (fileStream == null)
                throw new ArgumentNullException("fileStream");

            originalImage = new Bitmap(fileStream);
        }

        /// <summary>
        /// Initiates a new Resize from a bitmap
        /// </summary>
        /// <param name="bitmap"></param>
        public ResizeImage(Bitmap bitmap)
            : this()
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");

            originalImage = bitmap;
        }

        /// <summary>
        /// Internal constructor that sets default values
        /// </summary>
        private ResizeImage()
        {
            this.Method = ResizeMethod.Constrain;
        }

        /// <summary>
        /// Sets the resizing method to crop
        /// </summary>
        /// <returns></returns>
        public ResizeImage Crop()
        {
            this.Method = ResizeMethod.Crop;
            return this;
        }

        /// <summary>
        /// Sets the resizing method to pad
        /// </summary>
        /// <returns></returns>
        public ResizeImage Pad(Color color)
        {
            this.Method = ResizeMethod.Pad;
            this.PadColor = color;
            return this;
        }

        /// <summary>
        /// Sets the resizing method to pad
        /// </summary>
        /// <param name="htmlColor"></param>
        /// <returns></returns>
        public ResizeImage Pad(string htmlColor)
        {
            this.Method = ResizeMethod.Pad;
            this.PadColor = ColorTranslator.FromHtml(htmlColor);
            return this;
        }

        public ResizeImage Pad(Brush brush)
        {
            this.Method = ResizeMethod.Pad;
            this.PadBrush = brush;
            return this;
        }

        /// <summary>
        /// Sets the resizing method to distort
        /// </summary>
        /// <returns></returns>
        public ResizeImage Distort()
        {
            this.Method = ResizeMethod.Distort;
            return this;
        }

        /// <summary>
        /// Sets the resizing method to contstrain
        /// </summary>
        /// <returns></returns>
        public ResizeImage Constrain()
        {
            this.Method = ResizeMethod.Constrain;
            return this;
        }

        /// <summary>
        /// Sets the targeted size to the provided width and height
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public ResizeImage ToSize(int width, int height)
        {
            this.TargetSize = new Size(width, height);
            return this;
        }

        /// <summary>
        /// Sets the targeted size of the resize
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public ResizeImage ToSize(Size size)
        {
            this.TargetSize = size;
            return this;
        }

        /// <summary>
        /// Resizes the image with the set configuration
        /// and returns the bitmap of the resized image
        /// </summary>
        /// <returns>the resized image</returns>
        public Bitmap Save()
        {
            return MakeResize();
        }

        /// <summary>
        /// Resizes the image and saves it to the specified path 
        /// as an jpeg. Applies the provided quality
        /// </summary>
        /// <param name="path">the absolut path to save the image to</param>
        /// <param name="quality">Quality of the image, 1 to 100</param>
        /// <exception cref="T:ArgumentOutOfRangeException">if the quality is out of range</exception>
        /// <exception cref="T:ArgumentNullException">if the path is null or empty</exception>
        /// <returns>the path to the saved file</returns>
        public string SaveJpeg(string path, uint quality = 95, bool overwrite = false)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("path");

            if (quality < 1 || quality > 100)
                throw new ArgumentOutOfRangeException("quality", "Allowed values are 1 to 100");

            // make the resize
            using (var resizedImage = MakeResize())
                new ImageSaver().SaveJpeg(image: resizedImage, path: path, quality: quality, overwrite: overwrite);

            return path;
        }

        /// <summary>
        /// Saves the image as an jpg to the provided stream
        /// </summary>
        /// <param name="stream">the stream to save to</param>
        /// <param name="quality">the quality of the jpg</param>
        /// <exception cref="T:ArgumentNullException">stream</exception>
        /// <returns></returns>
        public Stream SaveJpeg(Stream stream, uint quality = 95)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            if (quality < 1 || quality > 100)
                throw new ArgumentOutOfRangeException("quality", "Allowed values are 1 to 100");

            using (var resizedImage = MakeResize())
                new ImageSaver().SaveJpeg(image: resizedImage, stream: stream, quality: quality);

            return stream;
        }

        /// <summary>
        /// Saves the image as a png to the specified path
        /// </summary>
        /// <param name="path">the target path</param>
        /// <returns></returns>
        public string SavePng(string path, bool overwrite = false)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("path");

            using (var resizedImage = MakeResize())
                new ImageSaver().SavePng(image: resizedImage, path: path, overwrite: overwrite);

            return path;
        }

        /// <summary>
        /// Saves the resized image as a png to the provided stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public Stream SavePng(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            using (var resizedImage = MakeResize())
                new ImageSaver().SavePng(image: resizedImage, stream: stream);

            return stream;
        }

        /// <summary>
        /// Makes the resize of the image depeding on the provided methods
        /// </summary>
        /// <returns></returns>
        private Bitmap MakeResize()
        {
            if (TargetSize.IsEmpty)
                TargetSize = originalImage.Size;

            if (PadBrush != null)
                return new Resizer().Resize(originalImage, Method, TargetSize, PadBrush);

            return new Resizer().Resize(originalImage, Method, TargetSize, PadColor);
        }

        /// <summary>
        /// Gets or sets the size of the resize
        /// </summary>
        public Size TargetSize { get; set; }

        /// <summary>
        /// Gets or sets the brush to use for padding
        /// </summary>
        public Brush PadBrush { get; set; }

        /// <summary>
        /// Gets or sets the Resize method
        /// </summary>
        public ResizeMethod Method { get; set; }

        /// <summary>
        /// Gets or sets the PadColor
        /// </summary>
        public Color PadColor { get; set; }

        /// <summary>
        /// Disposes the used resources
        /// </summary>
        public void Dispose()
        {
            originalImage.Dispose();
        }
    }
}
