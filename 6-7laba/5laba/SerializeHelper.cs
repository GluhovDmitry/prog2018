using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _5laba
{
    public static class SerializeHelper
    {
        private static readonly XmlSerializer Xs = new XmlSerializer(typeof(UserInfo));
        public static UserInfo LoadFromFile(string fileName)
        {
            using (var fileStream = File.OpenRead(fileName))
            {
                return (UserInfo)Xs.Deserialize(fileStream);
            }
        }
        public static void WriteToFile(string fileName, UserInfo data)
        {
            using (var fileStream = File.Create(fileName))
            {
                Xs.Serialize(fileStream, data);
            }
        }
    }
}