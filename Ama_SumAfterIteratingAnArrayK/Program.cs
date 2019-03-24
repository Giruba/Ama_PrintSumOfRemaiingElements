using System;

namespace Ama_SumAfterIteratingAnArrayK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sum of the remaining elements after iterating" +
                "over an array where elements remaining are the resultant" +
                "of subraction of their neighbours!");

            Console.WriteLine();

            int sum = GetSumOfElements();
            Console.WriteLine("Sum of the remaining elements is "+sum);

            Console.ReadLine();
        }

        private static int GetSumOfElements() {
            int sum = 0;

            Console.WriteLine("Enter the number of elements in the array");
            try
            {
                int noElements = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the elements separated by space");
                String[] elements = Console.ReadLine().Split(' ');
                int[] originalArray = new int[noElements];
                for (int i = 0; i < elements.Length; i++) {
                    originalArray[i] = int.Parse(elements[i]);
                }
                Console.WriteLine("Enter the number of iterations");
                int noIterations = int.Parse(Console.ReadLine());
                sum = GetSumOfRemainingElements(originalArray, noIterations);
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }

            return sum;
        }

        private static int GetSumOfRemainingElements(int[] originalArray, int iterations) {
            int result = 0;

            int currentLength = originalArray.Length;

            while ((currentLength != 1) && (iterations !=0))
            {
                int tempIndex = 0;
                int[] tempArray = new int[originalArray.Length-1];
                for (int i = 1; i < originalArray.Length; i++)
                {
                    if ((i - 1) >= 0)
                    {
                        tempArray[tempIndex++] = originalArray[i] - originalArray[(i - 1)];
                    }
                }
                originalArray = tempArray;
                currentLength = originalArray.Length;
                iterations -= 1;
            }

            if (currentLength == 1) {
                return originalArray[0];
            }
            if (iterations == 0) {
                for (int index = 0; index < currentLength; index++) {
                    result += originalArray[index];
                }
            }
            return result;
        }
    }
}
