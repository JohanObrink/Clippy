using Nancy;
using System;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Clippy.Applications.AssetServer.Infrastructure
{
    public static class AssetServerConfiguration
    {
        #region properties

        private static Func<string> mediaPath = () => GetMediaPathFromConfiguration();

        private static Regex metaRequestRegex = new Regex("[?&]meta([&=]|$)", RegexOptions.Compiled);
        
        /// <summary>
        /// MediaPath resolver. Defaults to GetMediaPathFromConfiguration
        /// </summary>
        public static Func<string> MediaPath
        {
            get { return mediaPath; }
            set { mediaPath = value; }
        }

        private static Regex imageSizeRegex =
            new Regex(@"^(?<path>(((?!\d{1,4}x\d{1,4})|[a-zA-Z0-9\-/]+?)))?(/(?<width>\d{1,4})x(?<height>\d{1,4}))?/(?<id>[a-zA-Z0-9\-]+)?(__(?<variant>[[a-zA-Z0-9\-]+))?(\((?<quality>\d{1,2}|100)\))?\.(?<filetype>[\w]{3,4})$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Parses the url and finds image size, format and jpeg quality
        /// </summary>
        public static Regex ImageDataRegex
        {
            get { return imageSizeRegex; }
            set { imageSizeRegex = value; }
        }

        private static Func<Request, bool> isMetaRequest = DefaultIsMetaRequest;
        public static Func<Request, bool> IsMetaRequest
        {
            get { return isMetaRequest; }
            set { isMetaRequest = value; }
        }

        #endregion

        #region defaults

        /// <summary>
        /// Default method of getting path to media
        /// </summary>
        /// <param name="key">Configuration key name. Defaults to "MediaLocation"</param>
        /// <returns></returns>
        public static string GetMediaPathFromConfiguration(string key = "MediaPath")
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static bool DefaultIsMetaRequest(Request request)
        {
            return metaRequestRegex.IsMatch(request.Url.Query);
        }

        #endregion
    }
}
