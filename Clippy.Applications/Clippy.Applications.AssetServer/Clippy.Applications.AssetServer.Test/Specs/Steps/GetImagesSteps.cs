using Clippy.Applications.AssetServer.Infrastructure;
using Clippy.Applications.AssetServer.Test.Helpers;
using FluentAssertions;
using Nancy;
using Nancy.Testing;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using TechTalk.SpecFlow;

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

            ScenarioContext.Current.Set<string>(original, "theImage");
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
            var resultImage = Bitmap.FromStream(response.Body.AsStream());

            resultImage.GetBytes().Should().BeEquivalentTo(originalImage.GetBytes());
        }
    }
}
