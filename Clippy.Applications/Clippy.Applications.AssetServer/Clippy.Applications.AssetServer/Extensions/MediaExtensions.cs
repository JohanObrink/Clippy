using Clippy.Applications.AssetServer.Infrastructure;
using System;
using System.IO;

namespace Clippy.Applications.AssetServer.Extensions
{
    public static class MediaExtensions
    {
        /// <summary>
        /// Converts a relative uri to an absolute file path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string AbsoluteMediaPath(this string path)
        {
            return
                Path.GetFullPath(
                    Path.Combine(
                        AssetServerConfiguration.MediaPath(), 
                        path.RemoveQuery().TrimStart('/')));
        }

        /// <summary>
        /// Resolves the mime type for the file path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string MimeType(this string path)
        {
            var extension = Path.GetExtension(path.RemoveQuery());
            switch (extension.TrimStart('.').ToLower())
            {
                case "png":
                    return "image/png";
                case "jpg":
                    return "image/jpeg";
                case "mp4":
                    return "video/mp4";
                case "mov":
                    return "video/quicktime";
                case "html":
                case "htm":
                    return "text/html";
                case "js":
                    return "text/javascript";
                case "css":
                    return "text/css";
                case "zip":
                    return "application/zip";
                default:
                    return "text/plain";
            }
        }

        /// <summary>
        /// Strips out any query part of the path
        /// </summary>
        /// <param name="pathAndQuery"></param>
        /// <returns></returns>
        public static string RemoveQuery(this string pathAndQuery)
        {
            if (pathAndQuery == null || !pathAndQuery.Contains("?"))
                return pathAndQuery;

            return pathAndQuery.Substring(0, pathAndQuery.IndexOf("?"));
        }
    }
}
