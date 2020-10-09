using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using Taika.Abstractions.Repository;
using Taika.Abstractions.Settings;

namespace Taika.Service.Settings
{
    public class SettingsService : ISettingsService
    {
        private readonly IConfiguration _configuration;
        public TaikaSettings TaikaSettings { get; set; }

        public SettingsService(IOptions<TaikaSettings> taikaSettings, IConfiguration configuration)
        {
            TaikaSettings = taikaSettings.Value;
            _configuration = configuration;
        }

        public (RepoData, bool) AddRepository(RepoData repoData)
        {
            TaikaSettings.Repositories.Add(repoData);
            return (repoData, true);
        }

        public (Guid, bool) RemoveRepository(Guid id)
        {
            TaikaSettings.Repositories.RemoveAll(p => p.Id == id);
            return (id, true);
        }

        public RepoData GetRepository(Guid id)
        {
            return TaikaSettings.Repositories.First(p => p.Id == id);
        }


        public IEnumerable<RepoData> GetRepositoryList()
        {
            return TaikaSettings.Repositories;
        }

        public string GetTheme()
        {
            return TaikaSettings.Theme;
        }

        public bool SetTheme(string value)
        {
            _configuration["Taika:Theme"] = value;
            
            var a = TaikaSettings.Theme;
            //TaikaSettings.Theme = value;
            //PersistSettings();
            return true; //for now.
        }


        private void PersistSettings()
        {
            
            
        }





        //public async Task<bool> UpdateFavIcon(MemoryStream streamData)
        //{
        //    return await _storageService.WriteToFile(streamData, TaikaDirectory.FavIconPath, true);
        //}

        //public async Task<bool> UpdateLogo(MemoryStream streamData)
        //{
        //    return await _storageService.WriteToFile(streamData, TaikaDirectory.LogoPath, true);
        //}




    }
}
