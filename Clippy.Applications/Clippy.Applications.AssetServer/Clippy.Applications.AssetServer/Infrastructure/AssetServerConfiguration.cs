using System;
using System.Configuration;

namespace Clippy.Applications.AssetServer.Infrastructure
{
    public static class AssetServerConfiguration
    {
        #region properties
        private static Func<string> mediaPath = () => GetMediaPathFromConfiguration();
        
        /// <summary>
        /// MediaPath resolver. Defaults to GetMediaPathFromConfiguration
        /// </summary>
        public static Func<string> MediaPath
        {
            get { return mediaPath; }
            set { mediaPath = value; }
        }
        #endregion

        #region defaults
        /// <summary>
        /// Default method of getting path to media
        /// </summary>
        /// <param name="key">Configuration key name. Defaults to "MediaLocation"</param>
        /// <returns></returns>
        public static string GetMediaPathFromConfiguration(string key = "MediaLocation")
        {
            return ConfigurationManager.AppSettings[key];
        }
        #endregion
    }
}
