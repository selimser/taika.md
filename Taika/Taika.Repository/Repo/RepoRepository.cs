using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Taika.Abstractions.Repository;
using Taika.Repository.Shared;

namespace Taika.Repository.Repo
{
    public class RepoRepository : RepositoryBase, IRepoRepository
    {
        private readonly IConfiguration _configuration;

        public RepoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(RepositoryData entity)
        {
            using (var connection = await SqlFactory.Create(_configuration.GetConnectionString(DbConnectionStringName)))
            {
                return await connection.ExecuteAsync
                (
                    sql: StoredProcedures.AddRepository,
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
                    sql: StoredProcedures.DeleteRepository,
                    commandType: CommandType.StoredProcedure,
                    param: spParams,
                    commandTimeout: 10
                );
            }
        }

        public async Task<IEnumerable<RepositoryData>> GetAllAsync()
        {
            using (var connection = await SqlFactory.Create(_configuration.GetConnectionString(DbConnectionStringName)))
            {
                return await connection.QueryAsync<RepositoryData>
                (
                    sql: StoredProcedures.GetAllRepositories,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
            }
        }

        public async Task<RepositoryData> GetByIdAsync(Guid id)
        {
            using (var connection = await SqlFactory.Create(_configuration.GetConnectionString(DbConnectionStringName)))
            {
                var spParams = new DynamicParameters();
                spParams.Add("@Id", id);

                return await connection.QuerySingleAsync<RepositoryData>
                (
                    sql: StoredProcedures.GetRepository,
                    commandType: CommandType.StoredProcedure,
                    param: spParams,
                    commandTimeout: 10
                );
            }
        }

        public async Task<int> UpdateAsync(RepositoryData entity)
        {
            using (var connection = await SqlFactory.Create(_configuration.GetConnectionString(DbConnectionStringName)))
            {
                return await connection.ExecuteAsync
                (
                    sql: StoredProcedures.UpdateRepository,
                    commandType: CommandType.StoredProcedure,
                    param: entity,
                    commandTimeout: 10
                );
            }
        }
    }
}
