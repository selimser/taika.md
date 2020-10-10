using Taika.Repository.Shared;
using Taika.Service.RepositoryService.Repository;

namespace Taika.Service.Repository
{
    public class RepoService : IRepoService
    {
        private readonly ITaikaUnit _taikaUnit;

        public RepoService(ITaikaUnit taikaUnit)
        {
            _taikaUnit = taikaUnit;
        }
    }
}
