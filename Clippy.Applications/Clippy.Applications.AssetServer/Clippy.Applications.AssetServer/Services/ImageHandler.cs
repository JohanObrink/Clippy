using Clippy.Applications.AssetServer.Infrastructure;
using Nancy;
using Nancy.Responses;
using System;
using System.Collections.Generic;

namespace Clippy.Applications.AssetServer.Services
{
    /// <summary>
    /// This is only for IOC convenience
    /// </summary>
    public interface IImageHandler : IResourceHandler
    {
    }


    public class ImageHandler : StaticResourceHandler, IImageHandler
    {
        /// <summary>
        /// Processes the path and query and returns the corresponding image resource
        /// </summary>
        /// <param name="pathAndQuery"></param>
        /// <returns></returns>
        public override Response GetResource(string pathAndQuery)
        {
            var imageData = AssetServerConfiguration.ImageDataRegex.Match(pathAndQuery);

            if (!imageData.Success)
                return new TextResponse("Bad Url Format") { StatusCode = HttpStatusCode.BadRequest };

            return new Response();
        }

        /// <summary>
        /// Processes the path, saves the image file and cleans up versions
        /// </summary>
        /// <param name="path"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public override Response SaveResource(string path, HttpFile file)
        {
            throw new NotImplementedException();
        }
    }
}
