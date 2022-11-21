namespace Taika.Core.Serializers
{
    public interface ITaikaSerialiser
    {
        string Serialise<TData>(TData target);
        TData Deserialise<TData>(string source);
    }
}
