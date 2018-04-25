using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//сайт знакомств
namespace _5laba
{
    class UserInfo
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public Adress Adress { get; set; }
        public List<Goal> Purpose { get; set; }
        public Orientation SOrientation { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
        Agender,
        Androgyne,
        Cisgender,
        Laminat,
        Other
    }
}
