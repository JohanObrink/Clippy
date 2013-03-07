using System;
using System.Data;
using System.Data.SqlClient;

namespace Clippy.Data
{
    /// <summary>
    /// IDataAccess for SqlServer
    /// </summary>
    public class SqlDataAccess : IDataAccess
    {
        private readonly Func<SqlConnection> connectionProvider;

        public SqlDataAccess(Func<SqlConnection> connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        /// <summary>
        /// Creates and executes a command as datareader
        /// </summary>
        /// <param name="command">The sql for the command</param>
        /// <param name="parameters">The parameters as any object type</param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string command, object parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var conn = connectionProvider.Invoke())
            {
                using (var cmd = new SqlCommand(command, conn))
                {
                    cmd.CommandType = commandType;
                    if (parameters != null)
                        cmd.AddParameters(parameters);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        var dataSet = new DataSet();
						adapter.Fill(dataSet);

                        return dataSet.CreateDataReader();
                    }
                }
            }
        }

        /// <summary>
        /// Creates and executes a command as non query
        /// </summary>
        /// <param name="command">The sql for the command</param>
        /// <param name="parameters">The parameters as any object type</param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string command, object parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
			using (var conn = connectionProvider.Invoke())
			{
				using (var cmd = new SqlCommand(command, conn))
				{
					cmd.CommandType = commandType;
					if (parameters != null)
						cmd.AddParameters(parameters);

					conn.Open();
					return cmd.ExecuteNonQuery();
				}
			}
        }

        /// <summary>
        /// Creates and executes a command as scalar
        /// </summary>
        /// <param name="command">The sql for the command</param>
        /// <param name="parameters">The parameters as any object type</param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public object ExecuteScalar(string command, object parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
			using (var conn = connectionProvider.Invoke())
			{
				using (var cmd = new SqlCommand(command, conn))
				{
					cmd.CommandType = commandType;
					if (parameters != null)
						cmd.AddParameters(parameters);

					conn.Open();
					return cmd.ExecuteScalar();
				}
			}
        }

        /// <summary>
        /// Creates and executes a command as scalar, casting it to T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The sql for the command</param>
        /// <param name="parameters">The parameters as any object type</param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public T ExecuteScalar<T>(string command, object parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
			return (T)ExecuteScalar(command, parameters, commandType);
        }
    }
}
