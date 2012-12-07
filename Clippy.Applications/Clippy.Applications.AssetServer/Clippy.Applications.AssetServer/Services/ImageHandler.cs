using Nancy;
using System;

namespace Clippy.Applications.AssetServer.Services
{
    public class ImageHandler : IResourceHandler
    {
        /// <summary>
        /// Processes the path and query and returns the corresponding image resource
        /// </summary>
        /// <param name="pathAndQuery"></param>
        /// <returns></returns>
        public Response GetResource(string pathAndQuery)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Processes the path, saves the image file and cleans up versions
        /// </summary>
        /// <param name="path"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public Response SaveResource(string path, HttpFile file)
        {
            throw new NotImplementedException();
        }
    }
}
