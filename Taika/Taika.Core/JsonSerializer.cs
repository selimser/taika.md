using System;

namespace Taika.Core
{
    public class JsonSerializer : ITaikaSerializer
    {
        public string DeserializeContext(string context)
        {
            return System.Text.Json.JsonSerializer.Deserialize<string>(context);
        }

        public string SerializeContext(string context)
        {
            throw new NotImplementedException();
        }
    }
}
