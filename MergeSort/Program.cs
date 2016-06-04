using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 8, 1, 6, 2, 5, 1, 3 ,10,0,15,5,100};

            Console.WriteLine("Array before sorting:");
            foreach (var t in input)
            {
                Console.Write(t + " ");
            }
            Console.WriteLine("");


            Console.WriteLine("Array after sorting:");
            Stopwatch stopwatch = Stopwatch.StartNew();
            MergeSort(input);
            stopwatch.Stop();
            foreach (var t in input)
            {
                Console.Write(t + " ");
            }
            Console.WriteLine("Execution Time: {0}", stopwatch.ElapsedMilliseconds);
            Console.Read();

        }

        public static void MergeSort(int[] nos)
        {
            int arrayLength = nos.Length;

            if (arrayLength < 2)
                return;
            int mid = arrayLength / 2;

            int[] left = new int[mid];
            int[] right = new int[arrayLength - mid];

            //if (mid == 1)
            //    left[0] = nos[0];

            for (int i = 0; i < mid; i++)
            {
                left[i] = nos[i];
            }

            for (int i = mid; i < arrayLength; i++)
            {
                right[i - mid] = nos[i];
            }

            MergeSort(left);
            MergeSort(right);
            Merge(left, right, nos);

        }

        private static void Merge(int[] left, int[] right, int[] nos)
        {
            int leftLen = left.Length, rightLen = right.Length;
            int i = 0, j = 0, k = 0;

            while (i < leftLen && j < rightLen)
            {
                if (left[i] < right[j])
                {
                    nos[k] = left[i];
                    i++;
                }
                else
                {
                    nos[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < leftLen)
            {
                nos[k] = left[i];
                i++;
                k++;
            }

            while (j < rightLen)
            {
                nos[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
