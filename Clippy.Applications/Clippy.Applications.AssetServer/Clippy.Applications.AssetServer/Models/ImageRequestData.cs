using System;

namespace Clippy.Applications.AssetServer.Models
{
    /// <summary>
    /// Typed variant of the image regex matching groups
    /// </summary>
    public class ImageRequestData
    {        
        /// <summary>
        /// The image id as in [image].ext
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// The directory path of the image as in [/foo/bar/]image.ext
        /// </summary>
        public virtual string Path { get; set; }

        /// <summary>
        /// The image file extension as in /image.[ext]
        /// </summary>
        public virtual string FileType { get; set; }

        /// <summary>
        /// The requested width of the image
        /// </summary>
        public virtual int? Width { get; set; }

        /// <summary>
        /// The requested height of the image
        /// </summary>
        public virtual int? Height { get; set; }

        /// <summary>
        /// A variant of an image as in /path/image__[variant].ext
        /// </summary>
        public virtual string Variant { get; set; }

        /// <summary>
        /// The requested quality of a jpeg
        /// </summary>
        public virtual uint? JpegQuality { get; set; }
    }
}
