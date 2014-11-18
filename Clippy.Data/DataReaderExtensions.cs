using System;
using System.Data;

namespace Clippy.Data
{
    public static class DataReaderExtensions
    {
        public static T Value<T>(this IDataReader reader, int index)
        {
            var type = typeof(T);
            var isNull = reader.IsDBNull(index);
            var val = (isNull) ? null : reader.GetValue(index);
            try
            {
                return (T)(object)val;
            }
            catch
            {
                throw new ArgumentException(string.Format("Column {0} ({1}) cannot be cast to a {2} with value {2}", index, reader.GetDataTypeName(index), type.Name, val ?? "null"));
            }
        }
    }
}
