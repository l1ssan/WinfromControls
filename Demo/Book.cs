using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Book
    {
        public string Name { get; set; }
        public string  Author { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
