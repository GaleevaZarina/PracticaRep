using System;
using System.IO;
using System.Linq;

namespace pr3_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileName = @"C:\Users\public.COPP\Desktop\water.txt";
           
            string line = "";
            StreamReader reader = new StreamReader(fileName);
            while (!reader.EndOfStream) 
            {
                line = reader.ReadLine();
            }
            reader.Close();

            int[] height = line.Split(' ').Select(int.Parse).ToArray();

            int maxWater = 0;
            
            for (int i = 0; i < height.Length; i++)
            {
                Console.Write($"{height[i]} ");
                int count = 1;
                for (int j = 0; j < height.Length; j++)
                {
                    if (height[i] >= height[j])
                    {
                        count = height[j] * Math.Abs((j - i));
                    }
                    else if (height[i] <= height[j])
                    {
                        count = height[i] * Math.Abs((j - i));
                    }
                    
                    if (count > maxWater)
                    {
                        maxWater = count;
                    }
                }
            }
            
            Console.WriteLine("\n" + maxWater);

        }
    }
}