using System;
using System.Data;
using Clippy.Data;
using Xunit;
using FluentAssertions;

namespace Clippy.Data.Test
{
    public class DataSetExtensionsTest
    {
        [Fact]
        public void It_can_add_a_DataTable()
        {
            var table = new DataTable();
            var set = new DataSet().AddTable(table);

            set.Tables.Count.Should().Be(1);
            set.Tables[0].Should().Be(table);
        }

        [Fact]
        public void It_can_create_a_table_with_no_name()
        {
            var set = new DataSet();
            var table = set.AddTable();

            set.Tables.Count.Should().Be(1);
            set.Tables[0].Should().Be(table);
            table.TableName.Should().Be("Table1");
        }

        [Fact]
        public void It_can_create_a_table_with_a_name()
        {
            var set = new DataSet();
            var table = set.AddTable("tableName");

            set.Tables.Count.Should().Be(1);
            set.Tables[0].Should().Be(table);
            table.TableName.Should().Be("tableName");
        }

        [Fact]
        public void It_can_add_columns()
        {
            var table = new DataTable()
                .AddColumn<int>("id")
                .AddColumn<string>("name")
                .AddColumn<DateTime>("date")
                .AddColumn<bool>("active");

            table.Columns.Count.Should().Be(4);

            table.Columns[0].ColumnName.Should().Be("id");
            table.Columns[0].DataType.Should().Be(typeof(int));

            table.Columns[1].ColumnName.Should().Be("name");
            table.Columns[1].DataType.Should().Be(typeof(string));

            table.Columns[2].ColumnName.Should().Be("date");
            table.Columns[2].DataType.Should().Be(typeof(DateTime));

            table.Columns[3].ColumnName.Should().Be("active");
            table.Columns[3].DataType.Should().Be(typeof(bool));
        }

        [Fact]
        public void It_can_add_data()
        {
            var today = DateTime.Now;
            var yesterday = DateTime.Now.Subtract(TimeSpan.FromDays(1));

            var table = new DataTable()
                .AddColumn<int>("id")
                .AddColumn<string>("name")
                .AddColumn<DateTime>("date")
                .AddColumn<bool>("active")

                .AddData(1, "foo", yesterday, true)
                .AddData(2, "bar", today, false);

            table.Rows.Count.Should().Be(2);

            table.Rows[0][0].Should().Be(1);
            table.Rows[0][1].Should().Be("foo");
            table.Rows[0][2].Should().Be(yesterday);
            table.Rows[0][3].Should().Be(true);

            table.Rows[1][0].Should().Be(2);
            table.Rows[1][1].Should().Be("bar");
            table.Rows[1][2].Should().Be(today);
            table.Rows[1][3].Should().Be(false);
        }
    }
}
