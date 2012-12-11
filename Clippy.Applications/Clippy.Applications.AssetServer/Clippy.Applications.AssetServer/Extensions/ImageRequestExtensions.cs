using Clippy.Core;
using Clippy.Applications.AssetServer.Models;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Clippy.Applications.AssetServer.Infrastructure;

namespace Clippy.Applications.AssetServer.Extensions
{
    public static class ImageRequestExtensions
    {
        public static ImageRequestData ToImageRequestData(this Match match)
        {
            var data = new ImageRequestData
            {
                Id = match.Groups["id"].Value,
                Width = match.Groups["width"].Value.ParseIntNullable(),
                Height = match.Groups["height"].Value.ParseIntNullable(),
                JpegQuality = match.Groups["quality"].Value.ParseUIntNullable(),
                FileType = match.Groups["filetype"].Value
            };

            //path
            if (!string.IsNullOrWhiteSpace(match.Groups["path"].Value))
                data.Path = match.Groups["path"].Value;

            //variant
            if (!string.IsNullOrWhiteSpace(match.Groups["variant"].Value))
                data.Variant = match.Groups["variant"].Value;

            return data;
        }

        public static string OriginalPath(this ImageRequestData data)
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(data.Path))
                sb.Append(data.Path);
            sb.AppendFormat("{0}.png", data.Id);

            return Path.Combine(Path.GetFullPath(AssetServerConfiguration.MediaPath()), sb.ToString());
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
