using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
    public class Location
    {
        public string Name { get; }
        public string Description { get; }
        public Dictionary<string, Location> Neighbors { get; }

        public Location(string name, string description)
        {
            Name = name;
            Description = description;
            Neighbors = new Dictionary<string, Location>();
        }
    }
}
