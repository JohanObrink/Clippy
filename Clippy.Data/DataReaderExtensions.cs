using System;
using System.Data;

namespace Clippy.Data
{
    public static class DataReaderExtensions
    {
        public static T Value<T>(this IDataReader reader, int index)
        {
            var isNull = reader.IsDBNull(index);
            var val = (isNull) ? null : reader.GetValue(index);
            try
            {
                return (T)(object)val;
            }
            catch
            {
                throw new ArgumentException(string.Format("Column {0} ({1}) cannot be cast to a {2} with value {3}", index, reader.GetDataTypeName(index), typeof(T).Name, val ?? "null"));
            }
        }
    }
}
