namespace Taika.Abstractions.Context
{
    public class TaikaContext
    {
        public Error Error { get; set; }
        public bool Success => Error == null;
    }
}
