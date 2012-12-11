using Clippy.Applications.AssetServer.Infrastructure;
using Nancy.Testing;
using System;

namespace Clippy.Applications.AssetServer.Test.Specs.Infrastructure
{
    public class TestBootstrapper : Bootstrapper
    {
        protected override void ConfigureRequestContainer(StructureMap.IContainer container, Nancy.NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            container.Configure(x =>
            {
                x.SelectConstructor(() => new ConfigurableNancyModule());
            });
        }
    }
}
