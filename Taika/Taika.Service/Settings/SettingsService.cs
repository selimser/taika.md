using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Taika.Abstractions.Settings;
using Taika.Core.Shared;
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

        public async Task<TaikaSetting> Get(string key)
        {
            try
            {
                var settingResult = await _taikaUnit.Settings.GetByIdAsync(key);

                return new TaikaSetting
                {
                    Key = key,
                    Value = settingResult.Value,
                    CreatedOn = settingResult.CreatedOn
                };
            }
            catch (Exception ex)
            {
                //log the error

                return new TaikaSetting
                {
                    Error = new Abstractions.Context.Error
                    {
                        Code = 999, //temp,
                        Message = ex.Message,
                        ExceptionData = ex
                    }
                };
            }
        }

        public async Task<TaikaSetting> Refresh(TaikaSetting setting)
        {
            try
            {
                var settingResult = await _taikaUnit.Settings.RefreshAsync(setting);

                return new TaikaSetting
                {
                    Key = setting.Key,
                    Value = setting.Value,
                    CreatedOn = setting.CreatedOn
                };
            }
            catch (Exception ex)
            {
                //log the error

                return new TaikaSetting
                {
                    Error = new Abstractions.Context.Error
                    {
                        Code = 999, //temp,
                        Message = ex.Message,
                        ExceptionData = ex
                    }
                };
            }
        }

        public async Task<TaikaSetting> Set(string key, string value)
        {
            try
            {
                var operationTime = DateTime.UtcNow;

                var keySetResult =
                    await _taikaUnit.Settings.AddOrUpdateAsync(new TaikaSetting
                    {
                        Key = key,
                        Value = value,
                        CreatedOn = operationTime
                    });

                return new TaikaSetting
                {
                    Key = key,
                    Value = value,
                    CreatedOn = operationTime
                };
            }
            catch (Exception ex)
            {
                //log the error

                return new TaikaSetting
                {
                    Error = new Abstractions.Context.Error
                    {
                        Code = 999, //temp,
                        Message = ex.Message,
                        ExceptionData = ex
                    }
                };
            }
        }



        //public async Task<bool> UpdateFavIcon()
        //{
        //    try
        //    {
        //        var result = await _taikaUnit.Settings.AddOrUpdateAsync(new TaikaSettingResult
        //        {
        //            Key = SettingKeys.FavIcon,
        //            Value = TaikaDirectory.FavIconPath,
        //            CreatedOn = DateTime.UtcNow
        //        });

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);

        //        //log the error.
        //        return false;
        //    }
        //}

        //public async Task<bool> UpdateLogo()
        //{
        //    try
        //    {
        //        var result = await _taikaUnit.Settings.AddOrUpdateAsync(new TaikaSettingResult
        //        {
        //            Key = SettingKeys.Logo,
        //            Value = TaikaDirectory.LogoPath,
        //            CreatedOn = DateTime.UtcNow
        //        });

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);

        //        //log the error.
        //        return false;
        //    }
        //}
    }
}
