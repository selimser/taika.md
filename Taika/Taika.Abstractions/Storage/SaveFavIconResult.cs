using Taika.Abstractions.Context;

namespace Taika.Abstractions.Storage
{
    public class SaveFavIconResult : TaikaContext
    {
        public string FilePath { get; set; }
    }
}
