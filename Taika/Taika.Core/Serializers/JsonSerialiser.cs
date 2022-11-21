using System.Text.Json;

namespace Taika.Core.Serializers
{
    public class JsonSerialiser : ITaikaSerialiser
    {
        public TData Deserialise<TData>(string source)
        {
            return JsonSerializer.Deserialize<TData>(source);
        }

        public string Serialise<TData>(TData target)
        {
            return JsonSerializer.Serialize<TData>(target);
        }
    }
}
