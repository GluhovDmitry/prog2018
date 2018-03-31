using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using laboratornaya2;
namespace QuickSort.Test
{
    [TestClass]
    public class QuickSortTest
    {
        //1
        [TestMethod]
        public void Test3ElementsArray()
        {
            bool value = false;
            var array = new int[3];
            var rnd = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(0, 10);
            Program.QuickSort(array);
            if (array[0] <= array[1] && array[1] <= array[2])
                value = true;
            Assert.AreEqual(value, true);
        }
        //2
        [TestMethod]
        public void Test100Elements()
        {
            bool value = false;
            var array = new int[100];
            var rnd = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(0, 10);
            Program.QuickSort(array);
            foreach (int e in array)
                if (array[e] <= array[e + 1])
                    value = true;
            Assert.AreEqual(value, true);
        }
        //3
        [TestMethod]
        public void Tes1000ElementsArray()
        {
            int value = 0;
            var k = 0;
            var array = new int[1000];
            var rnd = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(0, 10);
            Program.QuickSort(array);
            while (k <= 9) 
            {
                var num1 = rnd.Next(0, 998); //первое число пары
                var num2 = rnd.Next(num1, 999); //второе число пары
                if (array[num2] >= array[num1])
                {
                    value++; //счетчик пар, удовлетворяющих условию
                }
                k++; //счетчик пар
            }
            Assert.AreEqual(value, k);
        }
        //4
        [TestMethod]
        public void TestEmptyArray()
        {
            bool value = false;
            var array = new int[0];
            Program.QuickSort(array);
            foreach (int e in array)
                if (array[e] <= array[e + 1])
                    value = true;
            Assert.AreEqual(value, false);
        }
        //меньше 8 гб оперативы
    }
}
