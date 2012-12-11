using Clippy.Applications.AssetServer.Infrastructure;
using Clippy.Applications.AssetServer.Services;
using Nancy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Clippy.Applications.AssetServer
{
    public class CatchAllModule : NancyModule
    {
        public CatchAllModule(
            IImageHandler imageHandler,
            IMetaDataHandler metaDataHandler,
            IStaticResourceHandler staticResourceHandler,
            IErrorHandler errorHandler)
        {
            ///
            /// Handle errors
            /// 
            OnError += errorHandler.Handle;

            ///
            /// Catch requests with meta parameter
            ///
            Before += metaDataHandler.Handle;

            ///
            /// Catch image requests
            /// 
            Get[@"/(.*).png|.jpg"] = parameters =>
            {
                return imageHandler.GetResource(Request.Url.Path + Request.Url.Query);
            };

            ///
            /// Catch all
            /// 
            Get[@"/(.*)"] = parameters =>
            {
                return staticResourceHandler.GetResource(Request.Url.Path + Request.Url.Query);
            };
        }
    }
}
