using System;

namespace Taika.Abstractions.Repository
{
    public class RepositoryData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
