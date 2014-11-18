using System;
using System.Data;
using Clippy.Data;
using Xunit;
using FluentAssertions;

namespace Clippy.Data.Test
{
    public class DataReaderExtensionsTest
    {
        private readonly DataSet ds;
        private readonly DataTable dt;

        public DataReaderExtensionsTest()
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
            var reader = ds.CreateDataReader();
            reader.Read();
            reader.Value<int>(0).Should().Be(1);
            reader.Value<string>(1).Should().Be("Johan");
            reader.Value<DateTime>(2).Should().Be(new DateTime(1973, 4, 16));
            reader.Value<bool>(3).Should().BeTrue();
        }

        [Fact]
        public void It_can_read_nullable_values()
        {
            dt.AddData(null, null, null, null);
            var reader = ds.CreateDataReader();
            reader.Read();
            reader.Value<int?>(0).Should().NotHaveValue();
            reader.Value<string>(1).Should().BeNull();
            reader.Value<DateTime?>(2).Should().NotHaveValue();
            reader.Value<bool?>(3).Should().NotHaveValue();
        }

        [Fact]
        public void It_throws_if_null_is_found_for_non_nullable_type()
        {
            dt.AddData(null, null, null, null);
            var reader = ds.CreateDataReader();
            reader.Read();
            Assert.Throws<ArgumentException>(() => reader.Value<int>(0));
            Assert.Throws<ArgumentException>(() => reader.Value<DateTime>(2));
            Assert.Throws<ArgumentException>(() => reader.Value<bool>(3));
        }
    }
}
