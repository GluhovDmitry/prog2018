﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5laba
{
    public class Orientation
    {
        public TypesOrient SOrientation { get; set; }
    }
    public enum TypesOrient
    {
        Hetero,
        Homo,
        Bi,
        Cats
    }
}
