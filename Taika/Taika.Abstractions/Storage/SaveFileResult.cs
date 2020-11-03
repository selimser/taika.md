using Taika.Abstractions.Context;

namespace Taika.Abstractions.Storage
{
    public class SaveFileResult : TaikaContext
    {
        public string FilePath { get; set; }
    }
}
