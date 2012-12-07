using Clippy.Applications.AssetServer.Models;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Clippy.Applications.AssetServer.Extensions
{
    public static class ImageRequestExtensions
    {
        public static ImageRequestData ToImageRequestData(this Match match)
        {
            var data = new ImageRequestData
            {
                Id = match.Groups["id"].Value
            };

            //path
            if (!string.IsNullOrWhiteSpace(match.Groups["path"].Value))
                data.Path = match.Groups["path"].Value;

            //size
            if (!string.IsNullOrWhiteSpace(match.Groups["width"].Value))
            {
                
            }

            /*imageData.Groups["path"].Value.Should().Be("/foo");
            imageData.Groups["width"].Value.Should().Be("300");
            imageData.Groups["height"].Value.Should().Be("400");
            imageData.Groups["id"].Value.Should().Be("image");
            imageData.Groups["variant"].Value.Should().Be("darkside");
            imageData.Groups["quality"].Value.Should().Be("40");
            imageData.Groups["filetype"].Value.Should().Be("jpg");*/

            return data;
        }

        public static string ToUrl(this ImageRequestData data)
        {
            var url = new StringBuilder();

            //path
            if(!string.IsNullOrWhiteSpace(data.Path))
                url.Append(data.Path);
            url.Append("/");

            //size
            if (data.Width.HasValue && data.Height.HasValue)
                url.AppendFormat("{0}x{1}/", data.Width, data.Height);

            //id
            url.Append(data.Id);

            //variant
            if (!string.IsNullOrWhiteSpace(data.Variant))
                url.AppendFormat("__{0}", data.Variant);

            //quality
            if (data.JpegQuality.HasValue)
                url.AppendFormat("({0})", data.JpegQuality);

            //file type
            url.AppendFormat(".{0}", data.FileType);

            return url.ToString();
        }
    }
}
