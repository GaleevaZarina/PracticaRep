using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace pr3_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<int> nums = new List<int>();

            string fileName = @"C:\Users\public.COPP\Desktop\nums.txt";
            StreamReader reader = new StreamReader(fileName);
            while (!reader.EndOfStream) 
            {
                    
                string line = reader.ReadLine();
                    
                nums = line.Split(' ').Select(int.Parse).ToList();
            }
            reader.Close();
            
            StreamWriter writer = new StreamWriter(fileName);

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 != 0)
                {
                    writer.Write($"{nums[i]} ");
                }
            }
            
        }

    }
}