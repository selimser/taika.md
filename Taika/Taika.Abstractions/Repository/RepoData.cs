using System;

namespace Taika.Abstractions.Repository
{
    public class RepoData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string GitUrl { get; set; }
    }
}
