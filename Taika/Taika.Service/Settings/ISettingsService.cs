using System.Threading.Tasks;

namespace Taika.Service.Settings
{
    public interface ISettingsService
    {
        Task<string> GetTheme();
        Task<bool> SetTheme(string value);
    }
}
