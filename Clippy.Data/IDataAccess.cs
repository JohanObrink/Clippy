using System;
using System.Data;

namespace Clippy.Data
{
    public interface IDataAccess
    {
        /// <summary>
        /// Creates and executes a command as datareader
        /// </summary>
        /// <param name="command">The sql for the command</param>
        /// <param name="parameters">The parameters as any object type</param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        IDataReader ExecuteReader(string command, object parameters = null, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Creates and executes a command as non query
        /// </summary>
        /// <param name="command">The sql for the command</param>
        /// <param name="parameters">The parameters as any object type</param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string command, object parameters = null, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Creates and executes a command as scalar
        /// </summary>
        /// <param name="command">The sql for the command</param>
        /// <param name="parameters">The parameters as any object type</param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        object ExecuteScalar(string command, object parameters = null, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Creates and executes a command as scalar, casting it to T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The sql for the command</param>
        /// <param name="parameters">The parameters as any object type</param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        T ExecuteScalar<T>(string command, object parameters = null, CommandType commandType = CommandType.StoredProcedure);
    }
}
