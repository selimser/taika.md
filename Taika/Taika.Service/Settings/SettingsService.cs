using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Taika.Abstractions.Settings;
using Taika.Repository.Shared;

namespace Taika.Service.Settings
{
    public class SettingsService : ISettingsService
    {
        private readonly ITaikaUnit _taikaUnit;

        public SettingsService(ITaikaUnit taikaUnit)
        {
            _taikaUnit = taikaUnit;
        }

        public async Task<string> GetTheme()
        {
            var result = await _taikaUnit.Settings.GetByIdAsync(SettingKeys.Theme);
            return result.Value;
        }

        public async Task<bool> SetTheme(string value)
        {
            try
            {
                var result = await _taikaUnit.Settings.AddOrUpdateAsync(new TaikaSetting
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
