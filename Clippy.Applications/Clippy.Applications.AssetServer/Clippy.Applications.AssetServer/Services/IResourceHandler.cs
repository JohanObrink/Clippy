using Nancy;
using System;
using System.Collections.Generic;

namespace Clippy.Applications.AssetServer.Services
{
    public interface IResourceHandler
    {
        /// <summary>
        /// Processes the path and query and returns the corresponding resource
        /// </summary>
        /// <param name="pathAndQuery"></param>
        /// <returns></returns>
        Response GetResource(string pathAndQuery);

        /// <summary>
        /// Processes the path, saves the file and cleans up versions
        /// </summary>
        /// <param name="path"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        Response SaveResource(string path, HttpFile file);
    }
}
