using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RKIS_PR3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileName = @"D:\ТТИТ\РКИС\Практика\КОДЫ\input.txt";            
            StreamReader reader = new StreamReader(fileName);                        
            string[] lines = File.ReadAllLines(fileName);
            reader.Close();
            foreach (string s in lines)
            {
                Console.WriteLine(s);
            }            
            int[] luckyNumbers = new int[10];            
            List<int[]> tickets = new List<int[]>();
            for (int i = 0; i < lines.Length; i++)
            {
                int[] ticketsArray = new int [6];                
                string strocaInLines = lines[i];
                for (int k = 0; k < strocaInLines.Length; k++)
                {
                    if (i == 0)
                    {
                        luckyNumbers = strocaInLines.Split(' ').Select(int.Parse).ToArray();
                    }                    
                    else if (i > 1)
                    {
                        tickets.Add(strocaInLines.Split(' ').Select(int.Parse).ToArray());                        
                        break;
                    }
                }
            }            
            
            string fileName2 = @"D:\ТТИТ\РКИС\Практика\КОДЫ\output.txt";            
            StreamWriter writer = new StreamWriter(fileName2);            
            
            foreach (var item in tickets)
            {
                int luckyCount = 0;
                for (int i = 0; i < item.Length; i++)
                {
                    for (int j = 0; j < luckyNumbers.Length; j++)
                    {
                        if (item[i] == luckyNumbers[j] && item[i] != ' ')
                        {
                            luckyCount += 1;
                        }
                    }
                    
                }
                if (luckyCount >= 3)
                {
                    writer.WriteLine("Lucky");
                }
                else
                {
                    writer.WriteLine("Unlucky");
                }
            }
            
            writer.Close();
            
        }
    }
}

