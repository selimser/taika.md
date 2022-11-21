using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Taika.Repository.Storage
{
    public class StorageRepository : IStorageRepository
    {
        private readonly IConfiguration _configuration;

        public StorageRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> WriteToFile(Stream streamData, string targetFile, bool deleteExisting = false)
        {
            try
            {
                if (deleteExisting)
                {
                    File.Delete(targetFile);
                }

                using (var fStream = new FileStream(targetFile, FileMode.Create, FileAccess.Write))
                {
                    var streamBytes = new byte[streamData.Length];
                    await streamData.ReadAsync(streamBytes, 0, (int)streamData.Length);
                    await fStream.WriteAsync(streamBytes, 0, streamBytes.Length);
                    streamData.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                //log the error.
                return false;
            }
        }

        public async Task<MemoryStream> ReadStreamFromFile(string targetFile)
        {
            using (var mStream = new MemoryStream())
            {
                using (var fStream = new FileStream(targetFile, FileMode.Open, FileAccess.Read))
                {
                    var streamBytes = new byte[fStream.Length];
                    await fStream.ReadAsync(streamBytes, 0, (int)fStream.Length);
                    await mStream.WriteAsync(streamBytes, 0, (int)fStream.Length);
                }

                return mStream;
            }
        }

        public string ReadTextFromFile(string targetFile)
        {
            return File.ReadAllText(targetFile, Encoding.UTF8);
        }
    }
}
