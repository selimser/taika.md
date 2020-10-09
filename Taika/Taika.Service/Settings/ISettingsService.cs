using System;
using System.Collections.Generic;
using Taika.Abstractions.Repository;

namespace Taika.Service.Settings
{
    public interface ISettingsService
    {
        //Task<bool> UpdateFavIcon(MemoryStream streamData);
        //Task<bool> UpdateLogo(MemoryStream streamData);

        IEnumerable<RepoData> GetRepositoryList();
        RepoData GetRepository(Guid id);

        (RepoData, bool) AddRepository(RepoData repoData);
        (Guid, bool) RemoveRepository(Guid id);


        string GetTheme();
        bool SetTheme(string value);
    }
}
