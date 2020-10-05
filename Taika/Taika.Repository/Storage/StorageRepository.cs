using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taika.Abstractions.Repository;

namespace Taika.Repository.Storage
{
    public class StorageRepository : IStorageRepository
    {
        public Task<bool> AddRepository(RepoData repository)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RepoData>> GetAllRepositories()
        {
            throw new NotImplementedException();
        }

        public Task<RepoData> GetRepository(RepoData repository)
        {
            throw new NotImplementedException();
        }

        public Task<RepoData> GetRepository(Guid key)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetRepositoryCount()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveRepository(RepoData repository)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveRepository(Guid key)
        {
            throw new NotImplementedException();
        }
    }
}
