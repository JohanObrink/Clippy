using Clippy.Applications.AssetServer.Infrastructure;
using Nancy;
using System;

namespace Clippy.Applications.AssetServer.Services
{
    public interface IMetaDataHandler : IResourceHandler
    {
        Func<NancyContext, Response> Handle { get; }
    }

    public class MetaDataHandler : IMetaDataHandler
    {
        public Response GetResource(string pathAndQuery)
        {
            throw new NotImplementedException();
        }

        public Response SaveResource(string path, Nancy.HttpFile file)
        {
            throw new NotImplementedException();
        }

        public Func<NancyContext, Response> Handle
        {
            get
            {
                return ctx =>
                {
                    if (AssetServerConfiguration.IsMetaRequest(ctx.Request))
                    {
                        return "";
                    }

                    return (Response)null;
                };
            }
        }
    }
}
