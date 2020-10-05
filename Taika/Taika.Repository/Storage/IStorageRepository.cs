using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taika.Abstractions.Repository;

namespace Taika.Repository.Storage
{
    public interface IStorageRepository
    {
        Task<RepoData> GetRepository(RepoData repository);
        Task<RepoData> GetRepository(Guid key);
        Task<int> GetRepositoryCount();
        Task<IEnumerable<RepoData>> GetAllRepositories();
        Task<bool> AddRepository(RepoData repository);
        Task<bool> RemoveRepository(RepoData repository);
        Task<bool> RemoveRepository(Guid key);
    }
}
