using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Hashtable;

namespace _4laba
{
    public class HashTable
    {
        static void Main()
        {

        }
        class KeyValuePair
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }
        List<List<KeyValuePair>> list;
        public HashTable(int size)
        {
            list = new List<List<KeyValuePair>>();
            for (int i = 0; i < size; i++)
            {
                list.Add(new List<KeyValuePair>());
            }
        }
        public void PutPair(object key, object value)
        {
            var bucketNo = GetBucketNumber(key);
            foreach (var keyValuePair in list[bucketNo])
            {
                if (Equals(keyValuePair.Key, key))
                {
                    keyValuePair.Value = value;
                    return;
                }
            }
            list[bucketNo].Add(new KeyValuePair { Key = key, Value = value });
        }
        public object GetValueByKey(object key)
        {
            var BucketNo = GetBucketNumber(key);
            foreach (var keyValuePair in list[BucketNo])
            {
                if (Equals(keyValuePair.Key, key))
                {
                    return keyValuePair.Value;
                }
            }
            return null;
        }
        private int GetBucketNumber(object key)
        {
            return Math.Abs(key.GetHashCode()) % list.Count;
        }       
    }
}

