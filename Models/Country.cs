using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    internal class Country
    {
        public string Code { get; set; } 
        public string Name { get; set; }

        public Country()
        {
        }

        public Country(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
