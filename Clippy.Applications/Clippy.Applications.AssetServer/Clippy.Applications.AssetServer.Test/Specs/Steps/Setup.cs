using Clippy.Applications.AssetServer.Infrastructure;
using Clippy.Applications.AssetServer.Test.Specs.Infrastructure;
using Nancy;
using Nancy.Testing;
using StructureMap;
using System;
using System.IO;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Clippy.Applications.AssetServer.Test.Specs.Steps
{
    [Binding]
    public class Setup
    {
        [BeforeTestRun]
        public static void CreateAssetsFolder()
        {
            var folder = AssetServerConfiguration.MediaPath();
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }

        [AfterTestRun]
        public static void RemoveAssetsFolder()
        {
            var folder = AssetServerConfiguration.MediaPath();
            if (Directory.Exists(folder))
                Directory.Delete(folder, true);
        }

        [BeforeScenario]
        public void SetupNancy()
        {
            ScenarioContext.Current.Set<Browser>(new Browser(new TestBootstrapper()));
        }
    }
}
