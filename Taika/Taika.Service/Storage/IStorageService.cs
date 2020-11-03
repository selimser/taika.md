using System.IO;
using System.Threading.Tasks;
using Taika.Abstractions.Storage;

namespace Taika.Service.Storage
{
    public interface IStorageService
    {
        Task<SaveFileResult> SaveFile(string fileName, Stream streamData);
        Task<SaveLogoResult> SaveLogo(Stream streamData);
        Task<SaveFavIconResult> SaveFavIcon(Stream streamData);
    }
}
