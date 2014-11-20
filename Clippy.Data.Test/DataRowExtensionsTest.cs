using System;
using System.Data;
using Clippy.Data;
using Xunit;
using FluentAssertions;

namespace Clippy.Data.Test
{
    public class DataRowExtensionsTest
    {
        private readonly DataSet ds;
        private readonly DataTable dt;

        public DataRowExtensionsTest()
        {
            ds = new DataSet();
            dt = ds.AddTable("nonNullables")
                .AddColumn<int>("id")
                .AddColumn<string>("name")
                .AddColumn<DateTime>("birth")
                .AddColumn<bool>("alive");
        }

        [Fact]
        public void It_can_read_non_nullable_values()
        {
            dt.AddData(1, "Johan", new DateTime(1973, 4, 16), true);
            var row = dt.Rows[0];
            row.Value<int>(0).Should().Be(1);
            row.Value<string>(1).Should().Be("Johan");
            row.Value<DateTime>(2).Should().Be(new DateTime(1973, 4, 16));
            row.Value<bool>(3).Should().BeTrue();
        }

        [Fact]
        public void It_can_read_nullable_values()
        {
            dt.AddData(null, null, null, null);
            var row = dt.Rows[0];
            row.Value<int?>(0).Should().NotHaveValue();
            row.Value<string>(1).Should().BeNull();
            row.Value<DateTime?>(2).Should().NotHaveValue();
            row.Value<bool?>(3).Should().NotHaveValue();
        }

        [Fact]
        public void It_throws_if_null_is_found_for_non_nullable_type()
        {
            dt.AddData(null, null, null, null);
            var row = dt.Rows[0];
            Assert.Throws<ArgumentException>(() => row.Value<int>(0)).Message.Should().Be("Column 0 (Int32) cannot be cast to a Int32 with value null");
            Assert.Throws<ArgumentException>(() => row.Value<DateTime>(2));
            Assert.Throws<ArgumentException>(() => row.Value<bool>(3));
        }


        [Fact]
        public void It_can_read_non_nullable_values_with_name()
        {
            dt.AddData(1, "Johan", new DateTime(1973, 4, 16), true);
            var row = dt.Rows[0];
            row.Value<int>("id").Should().Be(1);
            row.Value<string>("name").Should().Be("Johan");
            row.Value<DateTime>("birth").Should().Be(new DateTime(1973, 4, 16));
            row.Value<bool>("alive").Should().BeTrue();
        }

        [Fact]
        public void It_can_read_nullable_values_with_name()
        {
            dt.AddData(null, null, null, null);
            var row = dt.Rows[0];
            row.Value<int?>("id").Should().NotHaveValue();
            row.Value<string>("name").Should().BeNull();
            row.Value<DateTime?>("birth").Should().NotHaveValue();
            row.Value<bool?>("alive").Should().NotHaveValue();
        }

        [Fact]
        public void It_throws_if_null_is_found_for_non_nullable_type_with_name()
        {
            dt.AddData(null, null, null, null);
            var row = dt.Rows[0];
            Assert.Throws<ArgumentException>(() => row.Value<int>("id")).Message.Should().Be("Column \"id\" (Int32) cannot be cast to a Int32 with value null");
            Assert.Throws<ArgumentException>(() => row.Value<DateTime>("birth"));
            Assert.Throws<ArgumentException>(() => row.Value<bool>("alive"));
        }
    }
}
