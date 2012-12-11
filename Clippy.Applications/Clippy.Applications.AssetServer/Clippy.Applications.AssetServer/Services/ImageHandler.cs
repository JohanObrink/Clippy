using Clippy.Applications.AssetServer.Infrastructure;
using Nancy;
using Nancy.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using Clippy.Applications.AssetServer.Extensions;

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
            // evaluate url
            var match = AssetServerConfiguration.ImageDataRegex.Match(pathAndQuery);

            // url malformed, throw
            if (!match.Success)
                return new TextResponse("Bad Url Format") { StatusCode = HttpStatusCode.BadRequest };

            var imageData = match.ToImageRequestData();
            var original = imageData.OriginalPath();
            
            // if original is missing, throw 404
            if (!File.Exists(original))
                throw new FileNotFoundException();

            // if original is requested, return the file
            if((!imageData.Width.HasValue || !imageData.Height.HasValue) && imageData.FileType == "png")
                return new GenericFileResponse(original);

            //var imageVersion = imageData.VersionPath();

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
