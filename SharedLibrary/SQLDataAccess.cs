using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SharedLibrary
{
    public class SQLDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SQLDataAccess(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// This is to return a List of data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProc"></param>
        /// <param name="connectionName"></param>
        /// <param name="paramseters"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<T>> ExecSP_RetData<T>(string storedProc, string connectionName, object? paramseters)
        {
            string connectionString = _config.GetConnectionString(connectionName)
                ?? throw new Exception($"Missing Connection String at {connectionName}");
            using var connection = new SqlConnection(connectionString);
            var rows = await connection.QueryAsync<T>(storedProc, paramseters, commandType: System.Data.CommandType.StoredProcedure);

            return rows.ToList();
        }

        /// <summary>
        /// This is to return No data, just to Execute a command
        /// </summary>
        /// <param name="storedProc"></param>
        /// <param name="connectionName"></param>
        /// <param name="paramseters"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task ExecSP_RetNoData(string storedProc, string connectionName, object paramseters)
        {
            string connectionString = _config.GetConnectionString(connectionName)
                ?? throw new Exception($"Missing Connection String at {connectionName}");

            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(storedProc, paramseters, commandType: System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// Return 1 or more values from SP
        ///  if (result is dynamic)
        // {
        //    // Access by property name (assuming your SP returns a single anonymous object)
        //        var returnValue1 = result.Property1;
        //        var returnValue2 = result.Property2;
        //    // ... and so on
        //    }
        //    else
        //    {
        //        // Handle other return types (e.g., single scalar value)
        //    }
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProc"></param>
        /// <param name="connectionName"></param>
        /// <param name="paramseters"></param>
        /// <param name="returnWhat"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<T> ExecSP_RetSingleValue<T>(string storedProc, string connectionName, object paramseters)
        {
            try
            {
                string connectionString = _config.GetConnectionString(connectionName)
                ?? throw new Exception($"Missing Connection String at {connectionName}");

                using var connection = new SqlConnection(connectionString);

                // Execute the stored procedure        
                object result = connection.QuerySingleAsync<dynamic>(storedProc, paramseters, commandType: System.Data.CommandType.StoredProcedure);
                return (T)result;
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                throw ex;
            }
        }
    }
}
