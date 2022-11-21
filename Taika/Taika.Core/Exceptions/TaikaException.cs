using System;

namespace Taika.Core.Exceptions
{
    public class TaikaException : Exception
    {
        public TaikaException() { }
        public TaikaException(string message) : base(message) { }
        public TaikaException(string message, Exception inner) : base(message, inner) { }
    }
}
