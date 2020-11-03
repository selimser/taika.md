using System;

namespace Taika.Abstractions.Context
{
    public class Error
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public Exception ExceptionData { get; set; }
    }
}
