using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication80
{
    class Program
    {
        public static int BinarySearch(int[] array, int value)
        {
            var left = 0;
            var right = array.Length - 1;
            while (left < right)
            {
                var middle = (left + right) / 2;
                if (value <= array[middle])
                    right = middle;
                else left = middle + 1;
            }
            if (right > 0 && array[right] == value)
                return right;
            return -1;
        }
        static void Main(string[] args)

        {
            TestFiveElements();
            TestNegativeNumbers();
            TestNonExistentElement();
            TestRepeatingElemets();
            TestEmptyArray();
            TestHugeArray();
            Console.ReadKey();
        }
        private static void TestFiveElements()
        {
            int[] numbers = new[] { 1, 2, 5, 8, 9 };
            if (BinarySearch(numbers, 5) != 2)
                Console.WriteLine(" Поиск не нашел число 5 среди чисел  { 1, 2, 5, 8, 9 } ");
            else
                Console.WriteLine("Поиск среди пяти чисел работает корректно");
            //Поиск одного элемента в массиве из 5 элементов
        }
        private static void TestNegativeNumbers()
        {
            int[] negativeNumbers = new[] { -5, -4, -3, -2 };
            if (BinarySearch(negativeNumbers, -3) != 2)
                Console.WriteLine("! Поиск не нашёл число -3 среди чисел {-5, -4, -3, -2}");
            else
                Console.WriteLine("Поиск среди отрицательных чисел работает корректно");
            //Поиск среди отрицательных чисел(реализован в шаблоне)
        }

        private static void TestNonExistentElement()
        {
            int[] negativeNumbers = new[] { -5, -4, -3, -2 };
            if (BinarySearch(negativeNumbers, -1) >= 0)
                Console.WriteLine("! Поиск нашёл число -1 среди чисел {-5, -4, -3, -2}");
            else
                Console.WriteLine("Поиск отсутствующего элемента работает корректно");
            //Поиск отсутствующего в массиве элемента(реализован в шаблоне)
        }
        private static void TestRepeatingElemets()
        {
            int[] repeatingNumbers = new[] { 2, 6, 8, 9, 9 };
            if (BinarySearch(repeatingNumbers, 9) != 3)
                Console.WriteLine("Поиск не нашел элемент в массиве с повторяющимися числами");
            else
                Console.WriteLine("Поиск повторяющегося элемента работает корректно");
            //Поиск элемента, повторяющегося несколько раз
        }
        private static void TestEmptyArray()
        {
            int[] emptyArray = new int[0];
            if (BinarySearch(emptyArray, 3) == -1)
                Console.WriteLine("Поиск элемента в пустом массиве работает корректно");
            else
                Console.WriteLine("Что-то пошло не так");
            //Поиск в пустом массиве (содержащем 0 элементов)
        }
        private static void TestHugeArray()
        {
            IEnumerable<int> squares = Enumerable.Range(1, 100001);
            int[] hugeArray = squares.ToArray();
            if (BinarySearch(hugeArray, 4) >= 0)
                Console.WriteLine("Поиск элемента в массиве из 100001 элементов работает корректно");
            else
                Console.WriteLine("Поиск не нашел такой элемент");
            //Поиск в массиве из 100001 элементов
        }
    }
}