using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//сайт знакомств
namespace _5laba
{
    public class UserInfo
    {
        public string Name { get; set; }
        public Gender Sex { get; set; }
        public decimal Age { get; set; }
        public Country Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public List<string> addGoal { get; set; }
        public TypesPurpose Purpose1 { get; set; }
        public TypesPurpose Purpose2 { get; set; }
        public TypesPurpose Purpose3 { get; set; }
        public TypesPurpose Purpose4 { get; set; }
        public TypesOrient SOrientation { get; set; }
        public static void Main(string[] args)
        {

        }
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
    public enum Country
    {
        Россия,
        Украина,
        Беларусь
    }
}