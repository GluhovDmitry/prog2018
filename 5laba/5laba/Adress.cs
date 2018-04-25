using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5laba
{
    class Adress
    {
        public Country Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
    }
    public enum Country
    {
        Russia,
        Ukraine,
        Belarus
    }
}
