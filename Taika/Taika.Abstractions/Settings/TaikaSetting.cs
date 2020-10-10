using System;

namespace Taika.Abstractions.Settings
{
    public class TaikaSetting
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
