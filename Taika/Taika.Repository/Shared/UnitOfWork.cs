using Taika.Repository.Repo;

namespace Taika.Repository.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepoRepository Repositories { get; }

        public UnitOfWork(IRepoRepository repoRepository)
        {
            Repositories = repoRepository;
        }


    }
}
