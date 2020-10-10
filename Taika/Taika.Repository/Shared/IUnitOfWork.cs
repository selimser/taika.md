using Taika.Repository.Repo;

namespace Taika.Repository
{
    public interface IUnitOfWork
    {
        IRepoRepository Repositories { get; }
    }
}
