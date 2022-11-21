using System.Threading.Tasks;
using Taika.Abstractions.Settings;

namespace Taika.Service.Settings
{
    public interface ISettingsService
    {
        /// <summary>
        /// Gets the specified setting key from the storage.
        /// </summary>
        /// <param name="key">The key for the setting</param>
        /// <returns>TaikaSetting with key, value and timestamp</returns>
        Task<TaikaSetting> Get(string key);

        /// <summary>
        /// Sets the specified setting key's value and updates timestamp.
        /// If the key does not exist, a new one will be created.
        /// </summary>
        /// <param name="key">The key for the setting</param>
        /// <param name="value">The value of the setting key</param>
        /// <returns>TaikaSetting with key, value and timestamp</returns>
        Task<TaikaSetting> Set(string key, string value);

        /// <summary>
        /// Updates the CreatedOn timestap only for a specific setting key.
        /// Does not update a setting key value.
        /// Use only for statistics update purposes.
        /// </summary>
        /// <param name="setting">The setting object that contains the refresh values</param>
        /// <returns>TaikaSetting with key, value and timestamp</returns>
        Task<TaikaSetting> Refresh(TaikaSetting setting);
    }
}
