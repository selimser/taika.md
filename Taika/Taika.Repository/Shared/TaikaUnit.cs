using Taika.Repository.Repo;
using Taika.Repository.Settings;

namespace Taika.Repository.Shared
{
    public class TaikaUnit : ITaikaUnit
    {
        public ISettingsRepository Settings { get; }
        public IRepoRepository Repositories { get; }

        public TaikaUnit(ISettingsRepository settingsRepository, IRepoRepository repoRepository)
        {
            Settings = settingsRepository;
            Repositories = repoRepository;
        }
    }
}
