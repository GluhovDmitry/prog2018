using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratornaya2
{
    public class Program
    {
        public static void QuickSort(int[] array, int low, int high)
        {
            if (high == low || array.Length == 0) return;
            var stick = array[high];
            var storeIndex = low;
            for (int i = low; i <= high - 1; i++)
                if (array[i] <= stick)
                {
                    var buf = array[i];
                    array[i] = array[storeIndex];
                    array[storeIndex] = buf;
                    storeIndex++;
                }
            var n = array[storeIndex];
            array[storeIndex] = array[high];
            array[high] = n;
            if (storeIndex > low) QuickSort(array, low, storeIndex - 1);
            if (storeIndex < high) QuickSort(array, storeIndex + 1, high);
        }
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        static int[] MakeArray(int lngth)
        {
            var array = new int[lngth];
            var rnd = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(0, 10);
            return array;
        }
        public static void Main()
        {
            var array = MakeArray(5);
            QuickSort(array);
            foreach (var value in array)
                Console.WriteLine(value);
            Console.ReadKey();
        }
    }
}
