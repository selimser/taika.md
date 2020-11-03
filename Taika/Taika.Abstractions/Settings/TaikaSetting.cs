using System;
using Taika.Abstractions.Context;

namespace Taika.Abstractions.Settings
{
    public class TaikaSetting : TaikaContext
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
