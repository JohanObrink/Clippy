using System;
using Xunit;
using FluentAssertions;

using Clippy.Applications.AssetServer.Extensions;
using Clippy.Applications.AssetServer.Infrastructure;
using System.IO;

namespace Clippy.Applications.AssetServer.Test.UnitTests.Extensions.MediaExtensions
{
    public class AbsoluteMediaPath
    {
        [Fact]
        public void It_returns_the_correct_path_for_absolute_MediaPath()
        {
            AssetServerConfiguration.MediaPath = () => @"c:\";

            "/foo/bar/baz.png".AbsoluteMediaPath().Should().Be(@"c:\foo\bar\baz.png");
        }

        [Fact]
        public void It_returns_the_correct_path_for_absolute_MediaPath_and_query()
        {
            AssetServerConfiguration.MediaPath = () => @"c:\";

            "/foo/bar/baz.png?query=string".AbsoluteMediaPath().Should().Be(@"c:\foo\bar\baz.png");
        }

        [Fact]
        public void It_returns_the_correct_path_for_relative_MediaPath()
        {
            AssetServerConfiguration.MediaPath = () => "./";
            var path = Path.GetFullPath("./");

            "/foo/bar/baz.png".AbsoluteMediaPath().Should().Be(path + @"foo\bar\baz.png");
        }

        [Fact]
        public void It_returns_the_correct_path_for_relative_MediaPath_and_query()
        {
            AssetServerConfiguration.MediaPath = () => "./";
            var path = Path.GetFullPath("./");

            "/foo/bar/baz.png?query=string".AbsoluteMediaPath().Should().Be(path + @"foo\bar\baz.png");
        }
    }
}
