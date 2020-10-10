using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Taika.Abstractions.Settings;
using Taika.Repository.Settings;

namespace Taika.Service.Settings
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _settingsRepository;

        public SettingsService(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public async Task<string> GetTheme()
        {
            var result = await _settingsRepository.GetByIdAsync(SettingKeys.Theme);
            return result.Value;
        }

        public async Task<bool> SetTheme(string value)
        {
            try
            {
                var result = await _settingsRepository.AddOrUpdateAsync(new TaikaSetting
                {
                    Key = SettingKeys.Theme,
                    Value = value,
                    CreatedOn = DateTime.UtcNow
                });

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                //log the error.
                return false;
            }
        }
    }
}
