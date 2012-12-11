using Clippy.Applications.AssetServer.Services;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.StructureMap;
using System;

namespace Clippy.Applications.AssetServer.Infrastructure
{
    public class Bootstrapper : StructureMapNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(StructureMap.IContainer existingContainer)
        {
            existingContainer.Configure(x =>
            {
                x.Scan(y =>
                {
                    y.AssemblyContainingType<IResourceHandler>();
                    y.WithDefaultConventions();
                });
            });
        }
    }
}
