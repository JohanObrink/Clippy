using System;
using Xunit;
using FluentAssertions;

using Clippy.Applications.AssetServer.Extensions;

namespace Clippy.Applications.AssetServer.Test.UnitTests.Extensions.MediaExtensions
{
    public class RemoveQuery
    {
        [Fact]
        public void It_removes_the_query_part_of_the_path()
        {
            "/foo/bar/baz.png?query=string".RemoveQuery().Should().Be("/foo/bar/baz.png");
        }

        [Fact]
        public void It_leaves_a_path_without_query()
        {
            "/foo/bar/baz.png".RemoveQuery().Should().Be("/foo/bar/baz.png");
        }
    }
}
