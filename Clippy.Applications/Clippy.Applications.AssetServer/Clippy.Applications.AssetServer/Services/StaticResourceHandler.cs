using System;
using System.IO;
using Nancy;
using Clippy.Applications.AssetServer.Extensions;
using Nancy.Responses;

namespace Clippy.Applications.AssetServer.Services
{
    public class StaticResourceHandler : IResourceHandler
    {
        /// <summary>
        /// Processes the path and query, locates the corresponding file
        /// and returns it
        /// </summary>
        /// <param name="pathAndQuery"></param>
        /// <returns></returns>
        public virtual Response GetResource(string pathAndQuery)
        {            
            var absolutePath = pathAndQuery.AbsoluteMediaPath();

            if (!File.Exists(absolutePath))
                throw new FileNotFoundException();

            return new GenericFileResponse(absolutePath, pathAndQuery.MimeType());
        }

        /// <summary>
        /// Returns a 403.
        /// Override to use.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public virtual Response SaveResource(string path, HttpFile file)
        {
            return new TextResponse("POST is not allowed") { StatusCode = HttpStatusCode.Forbidden };
        }
    }
}
