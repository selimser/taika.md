using System.Threading.Tasks;
using Taika.Abstractions.Settings;

namespace Taika.Repository.Settings
{
    public interface ISettingsRepository : IGenericRepository<TaikaSetting>
    {
        Task<TaikaSetting> GetByIdAsync(string key);
        Task<int> DeleteAsync(string key);
        Task<int> AddOrUpdateAsync(TaikaSetting setting);
        Task<int> RefreshAsync(TaikaSetting setting);
    }
}
