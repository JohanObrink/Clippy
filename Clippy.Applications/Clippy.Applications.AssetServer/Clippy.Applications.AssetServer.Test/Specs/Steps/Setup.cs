using Clippy.Applications.AssetServer.Infrastructure;
using System;
using System.IO;
using TechTalk.SpecFlow;

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
    }
}
