using System.IO;
using System.Threading.Tasks;

namespace Taika.Repository.Storage
{
    public interface IStorageRepository
    {
        Task<bool> WriteToFile(Stream streamData, string targetFile, bool deleteExisting = false);
        Task<MemoryStream> ReadStreamFromFile(string targetFile);
        string ReadTextFromFile(string targetFile);
    }
}
