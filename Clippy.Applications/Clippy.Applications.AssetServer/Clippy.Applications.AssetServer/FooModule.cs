using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Extensions;

namespace Clippy.Applications.AssetServer
{
    public class FooModule : NancyModule
    {
        public FooModule()
        {
            Get["/"] = x =>
            {
                return Response.AsJson(new { foo = "foo", bar = 1 });
            };
        }
    }
}
