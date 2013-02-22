using System;
using System.Data;
using System.Data.SqlClient;
using Clippy.Data;
using Xunit;
using FluentAssertions;

namespace Clippy.Data.Test
{
    public class DbCommandExtensionsTest
    {
        private SqlCommand cmd;

        public DbCommandExtensionsTest()
        {
            int? nullableInt = null;
            var parameters = new { a = "aVal", b = 1, c = false, d = nullableInt };
            cmd = new SqlCommand() { CommandType = CommandType.StoredProcedure };
            cmd.AddParameters(parameters);
        }

        [Fact]
        public void Parameters_are_added()
        {
            cmd.Parameters.Count.Should().Be(4);
        }

        [Fact]
        public void StringParameter_works()
        {
            var param = cmd.Parameters["a"];
            param.DbType.Should().Be(DbType.String);
            param.Value.Should().Be("aVal");
        }

        [Fact]
        public void Int32Parameter_works()
        {
            var param = cmd.Parameters["b"];
            param.DbType.Should().Be(DbType.Int32);
            param.Value.Should().Be(1);
        }

        [Fact]
        public void NullableInt32Parameter_works()
        {
            var param = cmd.Parameters["d"];
            param.DbType.Should().Be(DbType.Int32);
            param.Value.Should().Be(DBNull.Value);
        }

        [Fact]
        public void BoolParameter_works()
        {
            var param = cmd.Parameters["c"];
            param.DbType.Should().Be(DbType.Boolean);
            param.Value.Should().Be(false);
        }
    }
}
