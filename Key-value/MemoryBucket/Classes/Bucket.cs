using System.Collections.Generic;

namespace MemoryBucket.Classes
{
    public class Bucket
    {
        public string Name { get; set; }
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
    }
}
