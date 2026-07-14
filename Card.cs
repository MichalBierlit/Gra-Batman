using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
    public class Card
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Card(string name, int value)
        {
            Name = name;
            Value = value;
        }

    }
}
