using System.IO;
using System.Threading.Tasks;

namespace Taika.Service.Storage
{
    public interface IStorageService
    {
        Task<bool> WriteToFile(MemoryStream streamData, string targetFile, bool deleteExisting = false);
        Task<MemoryStream> ReadStreamFromFile(string targetFile);
        string ReadTextFromFile(string targetFile);
    }
}
