using Clippy.Applications.AssetServer.Infrastructure;
using Nancy.Testing;
using System;
using System.IO;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;
using FluentAssertions;
using Nancy;
using System.Drawing;

namespace Clippy.Applications.AssetServer.Test.Specs.Steps
{
    [Binding]
    public class GetImagesSteps
    {
        [Given(@"There is an image called ""(.*)""")]
        public void GivenThereIsAnImageCalled(string imagePath)
        {
            var original = Path.GetFullPath("./assets/clippy.png");
            var target = Path.Combine(AssetServerConfiguration.MediaPath(), imagePath.TrimStart('/'));

            File.Copy(original, target, true);

            ScenarioContext.Current.Set<string>("theImage", original);
        }

        [When(@"I visit ""(.*)""")]
        public void WhenIVisit(string url)
        {
            ScenarioContext.Current.Set<BrowserResponse>(ScenarioContext.Current.Get<Browser>().Get(url, with => { with.HttpRequest(); }));
        }

        [Then(@"I should see the image")]
        public void ThenIShouldSee()
        {
            var imagePath = ScenarioContext.Current.Get<string>("theImage");
            var response = ScenarioContext.Current.Get<BrowserResponse>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var originalImage = Bitmap.FromFile(imagePath);
        }
    }
}
