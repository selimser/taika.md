using System;
using System.Collections.Generic;
using Taika.Abstractions.Repository;

namespace Taika.Abstractions.Settings
{
    public class TaikaSettings
    {
        public string Theme { get; set; }
        public List<RepoData> Repositories { get; set; }
    }
}
