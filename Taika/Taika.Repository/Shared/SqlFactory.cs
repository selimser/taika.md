using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Taika.Repository.Shared
{
    internal static class SqlFactory
    {
        internal static async Task<SqlConnection> Create(string connectionString)
        {
            var sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync(); //handle opening exceptions.
            return sqlConnection;
        }


        [Obsolete("Parking this idea for now, not worth the effort")]
        internal static DynamicParameters GenerateParameters<TInput>(params KeyValuePair<string, TInput>[] spParams)
        {
            var dynamicParams = new DynamicParameters();
            foreach (var parameter in spParams)
            {
                dynamicParams.Add(parameter.Key, parameter.Value);
            }

            return dynamicParams;
        }
    }
}
