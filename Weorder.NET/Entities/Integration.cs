using System;
using System.Collections.Generic;
using System.Text;

namespace Weorder.NET.Entities
{
    public class Integration
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public Payload payload { get; set; }
        public bool enabled { get; set; }

    }
}
