using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Clippy.Data
{
    /// <summary>
    /// Extensions to DbCommand for building command parameters
    /// </summary>
    public static class DbCommandExtensions
    {
        /// <summary>
        /// Convert object to SqlParameters and add to Command
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DbCommand AddParameters(this DbCommand cmd, object parameters)
        {
            parameters
                .ToSqlParameters(cmd)
                .ToList()
                .ForEach(x => cmd.Parameters.Add(x));
            return cmd;
        }
    
        /// <summary>
        /// Convert an object into an IEnumerable&lt;DbParameter&gt;
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static IEnumerable<DbParameter> ToSqlParameters(this object parameters, DbCommand cmd)
        {
            if (parameters is ExpandoObject)
            {
                var dict = parameters as IDictionary<string, object>;
                foreach (var key in dict.Keys)
                    yield return cmd.GetParameter(key, dict[key], dict[key].GetType());
            }
            else
            {
                foreach (var propInfo in parameters.GetType().GetProperties().Where(x => x.CanRead))
                    yield return cmd.GetParameter(parameters, propInfo);
            }
        }

        /// <summary>
        /// Builds a DbParameter from a reflected property on an object, reflecting it's property type
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        /// <param name="propInfo"></param>
        /// <returns></returns>
        public static DbParameter GetParameter(this DbCommand cmd, object parameters, PropertyInfo propInfo)
        {
            return cmd.GetParameter(propInfo.Name, propInfo.GetValue(parameters, null), propInfo.PropertyType);
        }

        /// <summary>
        /// Builds a DbParameter from a reflected property on an object
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        /// <param name="propInfo"></param>
        /// <returns></returns>
        public static DbParameter GetParameter(this DbCommand cmd, string parameterName, object parameterValue, Type parameterType)
        {
            var param = cmd.CreateParameter();
            param.ParameterName = parameterName;

            if (parameterType.Equals(typeof(int?)))
                param.DbType = DbType.Int32;

            param.Value = parameterValue ?? DBNull.Value;


            return param;
        }
    }
}
