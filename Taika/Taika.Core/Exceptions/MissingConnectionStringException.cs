using System;

namespace Taika.Core.Exceptions
{
    public class MissingConnectionStringException : TaikaException
    {
        public MissingConnectionStringException() { }
        public MissingConnectionStringException(string message) : base(message) { }
        public MissingConnectionStringException(string message, Exception inner) : base(message, inner) { }
    }
}
