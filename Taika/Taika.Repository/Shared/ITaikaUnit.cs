using Taika.Repository.Repo;
using Taika.Repository.Settings;

namespace Taika.Repository.Shared
{
    public interface ITaikaUnit
    {
        ISettingsRepository Settings { get; }
        IRepoRepository Repositories { get; }
    }
}
