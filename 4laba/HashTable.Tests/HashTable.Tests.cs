using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTable.Tests
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        //Добавление трёх элементов, поиск трёх элементов
        public void ThreeElementsTest()
        {
            var hashTable = new _4laba.HashTable(3);
            hashTable.PutPair("1", "Petya");
            hashTable.PutPair("3", "Sasha");
            hashTable.PutPair("6", "Lesha");
            Assert.AreEqual(hashTable.GetValueByKey("1"), "Petya");
            Assert.AreEqual(hashTable.GetValueByKey("3"), "Sasha");
            Assert.AreEqual(hashTable.GetValueByKey("6"), "Lesha");
        }
        //Добавление одного и того же ключа дважды с разными значениями сохраняет последнее добавленное значение
        [TestMethod]
        public void EqualKeysTest()
        {
            var hashTable = new _4laba.HashTable(3);
            hashTable.PutPair("1", "Petya");
            hashTable.PutPair("1", "Vasya");
            Assert.AreEqual(hashTable.GetValueByKey("1"), "Vasya");
        }
        //Добавление 10000 элементов в структуру и поиск одного из них
        [TestMethod]
        public void TenThousandElements()
        {
            var hashTable = new _4laba.HashTable(10000);
            for (int i = 0; i < 10000; i++) 
            {
                hashTable.PutPair(i, i+"/");
            }
            Assert.AreEqual(hashTable.GetValueByKey(12), "12/");
        }


        //Добавление 10000 элементов в структуру и поиск 1000 недобавленных ключей, поиск которых должен вернуть null
        [TestMethod]
        public void TenThousandElementsAndThousandNulls()
        {
            var hashTable = new _4laba.HashTable(10000);
            for (int i = 0; i < 9000; i++)
            {
                hashTable.PutPair(i, i + "/");
            }
            Assert.AreEqual(hashTable.GetValueByKey(12), "12/");
            Assert.AreEqual(hashTable.GetValueByKey(9001), null);
        }
    }
}
