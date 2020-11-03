using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Taika.Abstractions.Settings;
using Taika.Repository.Shared;

namespace Taika.Repository.Settings
{
    public class SettingsRepository : RepositoryBase, ISettingsRepository
    {
        private readonly IConfiguration _configuration;

        public SettingsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(TaikaSetting entity)
        {
            using (var connection = await SqlFactory.Create(_configuration.GetConnectionString(DbConnectionStringName)))
            {
                return await connection.ExecuteAsync
                (
                    sql: StoredProcedures.AddSetting,
                    commandType: CommandType.StoredProcedure,
                    param: entity,
                    commandTimeout: 10
                );
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using (var connection = await SqlFactory.Create(_configuration.GetConnectionString(DbConnectionStringName)))
            {
                var spParams = new DynamicParameters();
                spParams.Add("@Id", id);

                return await connection.ExecuteAsync
                (
                    sql: StoredProcedures.DeleteSetting,
                    commandType: CommandType.StoredProcedure,
                    param: spParams,
                    commandTimeout: 10
                );
            }
        }

        public async Task<IEnumerable<TaikaSetting>> GetAllAsync()
        {
            using (var connection = await SqlFactory.Create(_configuration.GetConnectionString(DbConnectionStringName)))
            {
                return await connection.QueryAsync<TaikaSetting>
                (
                    sql: StoredProcedures.GetAllSettings,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
            }
        }

        public async Task<TaikaSetting> GetByIdAsync(Guid id)
        {
            using (var connection = await SqlFactory.Create(_configuration.GetConnectionString(DbConnectionStringName)))
            {
                var spParams = new DynamicParameters();
                spParams.Add("@Id", id);

                return await connection.QuerySingleAsync<TaikaSetting>
                (
                    sql: StoredProcedures.GetSetting,
                    commandType: CommandType.StoredProcedure,
                    param: spParams,
                    commandTimeout: 10
                );
            }
        }

        public async Task<int> UpdateAsync(TaikaSetting entity)
        {
            using (var connection = await SqlFactory.Create(_configuration.GetConnectionString(DbConnectionStringName)))
            {
                return await connection.ExecuteAsync
                (
                    sql: StoredProcedures.UpdateSetting,
                    commandType: CommandType.StoredProcedure,
                    param: entity,
                    commandTimeout: 10
                );
            }
        }

        public async Task<TaikaSetting> GetByIdAsync(string key)
        {
            using (var connection = await SqlFactory.Create(_configuration.GetConnectionString(DbConnectionStringName)))
            {
                var spParams = new DynamicParameters();
                spParams.Add("@Key", key);

                return await connection.QuerySingleAsync<TaikaSetting>
                (
                    sql: StoredProcedures.GetSetting,
                    commandType: CommandType.StoredProcedure,
                    param: spParams,
                    commandTimeout: 10
                );
            }
        }

        public async Task<int> DeleteAsync(string key)
        {
            using (var connection = await SqlFactory.Create(_configuration.GetConnectionString(DbConnectionStringName)))
            {
                var spParams = new DynamicParameters();
                spParams.Add("@Key", key);

                return await connection.ExecuteAsync
                (
                    sql: StoredProcedures.DeleteSetting,
                    commandType: CommandType.StoredProcedure,
                    param: spParams,
                    commandTimeout: 10
                );
            }
        }

        public async Task<int> AddOrUpdateAsync(TaikaSetting setting)
        {
            using (var connection = await SqlFactory.Create(_configuration.GetConnectionString(DbConnectionStringName)))
            {
                var spParams = new DynamicParameters();
                spParams.Add("@Key", setting.Key);
                spParams.Add("@Value", setting.Value);
                spParams.Add("@CreatedOn", DateTime.UtcNow);

                return await connection.ExecuteAsync
                (
                    sql: StoredProcedures.AddOrUpdateSetting,
                    commandType: CommandType.StoredProcedure,
                    param: spParams,
                    commandTimeout: 10
                );
            }
        }

        public async Task<int> RefreshAsync(TaikaSetting setting)
        {
            using (var connection = await SqlFactory.Create(_configuration.GetConnectionString(DbConnectionStringName)))
            {
                var spParams = new DynamicParameters();
                spParams.Add("@Key", setting.Key);
                spParams.Add("@Value", setting.Value);
                spParams.Add("@CreatedOn", DateTime.UtcNow);

                return await connection.ExecuteAsync
                (
                    sql: StoredProcedures.RefreshSetting,
                    commandType: CommandType.StoredProcedure,
                    param: spParams,
                    commandTimeout: 10
                );
            }
        }
    }
}
