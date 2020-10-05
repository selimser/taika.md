using System.IO;

namespace Taika.Core
{
    public interface ITaikaSerializer
    {
        string DeserializeContext(string context);
        string SerializeContext(string context);
    }
}
