using Taika.Abstractions.Context;

namespace Taika.Abstractions.Storage
{
    public class SaveLogoResult : TaikaContext
    {
        public string FilePath { get; set; }
    }
}
