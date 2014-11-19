using System;
using System.Data;

namespace Clippy.Data
{
    public static class DataRowExtensions
    {
        public static T Value<T>(this DataRow row, int index)
        {
            var isNull = row.IsNull(index);
            var val = (isNull) ? null : row[index];
            try
            {
                return (T)(object)val;
            }
            catch
            {
                throw new ArgumentException(string.Format("Column {0} ({1}) cannot be cast to a {2} with value {3}", index, row.Table.Columns[index].DataType.Name, typeof(T).Name, val ?? "null"));
            }
        }
    }
}
