using System;
using System.IO;
using Nancy;
using Clippy.Applications.AssetServer.Extensions;
using Nancy.Responses;

namespace Clippy.Applications.AssetServer.Services
{
    public class StaticResourceHandler : IResourceHandler
    {
        public Response GetResource(string pathAndQuery)
        {            
            var absolutePath = pathAndQuery.AbsoluteMediaPath();

            if (!File.Exists(absolutePath))
                throw new FileNotFoundException();

            return new GenericFileResponse(absolutePath, pathAndQuery.MimeType());
        }

        public Response SaveResource(string path, HttpFile file)
        {
            throw new NotImplementedException();
        }
    }
}
