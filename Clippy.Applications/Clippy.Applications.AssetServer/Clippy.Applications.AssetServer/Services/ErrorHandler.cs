using Nancy;
using System;
using System.IO;

namespace Clippy.Applications.AssetServer.Services
{
    public interface IErrorHandler
    {
        Func<NancyContext, Exception, Response> Handle { get; }
    }

    public class ErrorHandler : IErrorHandler
    {
        public Func<NancyContext, Exception, Response> Handle
        {
            get
            {
                return (ctx, ex) =>
                {
                    if (typeof(FileNotFoundException).IsAssignableFrom(ex.GetType()))
                        return new NotFoundResponse();
                    else
                        return (Response)null;
                };
            }
        }
    }
}
