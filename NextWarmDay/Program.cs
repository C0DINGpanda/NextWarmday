using System;
using System.Collections.Generic;

namespace NextWarmDay
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please provide the array range 1-3000");
                int length = int.Parse(Console.ReadLine());
                ValidateRange(1, 3000, length);

                int[] inputTemp = new int[length];
                Console.WriteLine("Please provide the Temperatures ranging of 30 to 100");
                for (int p = 0; p < length; p++)
                {
                    int val = int.Parse(Console.ReadLine());
                    ValidateRange(30, 100, val);
                    inputTemp[p] = val;
                }

                Console.WriteLine("computed warm days array is");
                ComputeNextWarmDay(inputTemp).ForEach(Console.WriteLine);
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void ValidateRange(int min, int max, int val)
        {
            if (!(val <= max && val >= min))
            {
                throw new Exception("input is not in provided range");
            }
        }

        private static List<int> ComputeNextWarmDay(int[] inputTemp)
        {
            List<int> warmdays = new List<int>();
            for (int i=0;i< inputTemp.Length;i++)
            {
                int daysCount = 0;

                for (int j = i+1; j < inputTemp.Length; j++)
                {
                    daysCount += 1;
                    if (inputTemp[i] < inputTemp[j])
                    {
                        warmdays.Add(daysCount);
                        break;
                    }
                    if (inputTemp.Length-j-1 ==0 )
                    {
                        warmdays.Add(0);
                    }
                }
            }
            warmdays.Add(0);
            return warmdays;
        }
    }
} 
