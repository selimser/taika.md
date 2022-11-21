using System;
using System.IO;
using System.Threading.Tasks;
using Taika.Abstractions.Context;
using Taika.Abstractions.Storage;
using Taika.Core.Shared;
using Taika.Repository.Storage;

namespace Taika.Service.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorageRepository _storageRepository;

        public StorageService(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        public async Task<SaveLogoResult> SaveLogo(Stream streamData)
        {
            try
            {
                var writeResult =
                    await _storageRepository.WriteToFile
                    (
                        streamData: streamData,
                        targetFile: TaikaDirectory.LogoPath,
                        deleteExisting: true
                    );

                return new SaveLogoResult { FilePath = TaikaDirectory.LogoPath };
            }
            catch (Exception ex)
            {
                return new SaveLogoResult
                {
                    Error = new Error
                    {
                        Code = -1, //temp
                        Message = ex.Message,
                        ExceptionData = ex
                    }
                };
            }
        }

        public async Task<SaveFavIconResult> SaveFavIcon(Stream streamData)
        {
            try
            {
                var writeResult =
                    await _storageRepository.WriteToFile
                    (
                        streamData: streamData,
                        targetFile: TaikaDirectory.FavIconPath,
                        deleteExisting: true
                    );

                return new SaveFavIconResult { FilePath = TaikaDirectory.FavIconPath };
            }
            catch (Exception ex)
            {
                return new SaveFavIconResult
                {
                    Error = new Error
                    {
                        Code = -1, //temp
                        Message = ex.Message,
                        ExceptionData = ex
                    }
                };
            }
        }

        public Task<SaveFileResult> SaveFile(string fileName, Stream streamData)
        {
            throw new System.NotImplementedException();
        }
    }
}
