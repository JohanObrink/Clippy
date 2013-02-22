using System;
using System.Linq;
using System.Data;

namespace Clippy.Data
{
    /// <summary>
    /// Utility extensions for fluent DataSet manipulation
    /// This is useable for creating test IDataReaders
    /// </summary>
    public static class DataSetExtensions
    {
        public static DataSet AddTable(this DataSet set, DataTable table)
        {
            set.Tables.Add(table);
            return set;
        }

        public static DataTable AddTable(this DataSet sd, string tableName = null)
        {
            return string.IsNullOrWhiteSpace(tableName)
                ? sd.Tables.Add()
                : sd.Tables.Add(tableName);
        }

        public static DataTable AddColumn<T>(this DataTable dt, string columnName)
        {
            dt.Columns.Add(columnName, typeof(T));
            return dt;
        }

        public static DataTable AddData(this DataTable dt, params object[] data)
        {
            dt.LoadDataRow(data, LoadOption.OverwriteChanges);
            return dt;
        }
    }
}
