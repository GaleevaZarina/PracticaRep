using System;
using System.Collections.Generic;

namespace pr2_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] temperature = new int[12, 30]; // Создаем двумерный массив, в котором будет хранитя температура каждого месяца (на 30 дней каждого месяца)
                                                  
            Random rnd = new Random();
            
            // Создаем цикл в цикле для заполнения двумерного массива temperature рандомным числами
            for (int i = 0; i < 12; i++)            
            {               
                Console.Write($"{i+1} месяц:\t"); // Для удобства выводим номер месяца
                                                  
                for (int j = 0; j < 30; j++)                
                {                    
                    temperature[i, j] = rnd.Next(-20, 30); // Температура будет в диапазоне от -20 до 30
                                                           
                    Console.Write(temperature[i, j] + "\t"); // Сразу выводим двумерный массив
                }                
                Console.WriteLine(""); // Переход на нрвую строку
                
            }                        
            Console.WriteLine("Средняя температура каждого месяца: ");            
            double[] temperatureSr = FindSrTemp(temperature); /* Создаем массиву temperatureSr, в который сохраним             
            среднюю температуру каждого месяца. Присваиваем массиву temperatureSr значение, которое возвращает нам метод FindSrTemp*/            
            
            // С помощью цикла foreach выводи массив temperatureSr (выводим среднюю температуру а каждый месяц)
            foreach (double item in temperatureSr)
            {
                Console.Write(item + ";  ");
            }           
            Array.Sort(temperatureSr); // Сортируем массив temperatureSr по возрастанию
                                       
            Array.Reverse(temperatureSr); // Переворачиваем массив temperatureSr
                                          
            Console.WriteLine("\nТемпература отсортирована по убыванию: ");           
            
            // С помощью цикла foreach выводим массив temperatureSr отсортированный по убыванию
            foreach (double item in temperatureSr)
            {
                Console.Write(item + ";  ");
            }        
        }                
        
        /* Создаем метод FindSrTemp для поиска средней температуры каждого месяца.
         Метод принимает 1 параметр: двумерный массив с температурами; Метод возвращает массив со средними температурами*/        
        public static  double[] FindSrTemp(int[,] array)        
        {            
            double[] temperatureSr = new double [12]; // Создаем массив temperatureSr, в который будем записывать найденную среднюю температуру
                                                      
            // Используем цикл в цикле для вычисления средней температур в каждом месяце и ее записи в массив temperatureSr
            for (int i = 0; i < 12; i++)            
            {                
                double sum = 0; // Создаем переменную sum для подсчета суммы температуры за весь месяц (нужноо, чтоы посчитать среднюю)
                for (int j = 0; j < 30; j++)                
                {                    
                    sum += array[i, j]; // Суммируем все значения в строке
                    
                }               
                temperatureSr[i] = Math.Round((sum / 30), 2); // Находим среднюю температуру за месяц и присваиваем это значение элементу массива temperatureSr
                
            }            
            return temperatureSr; // Метод возвращает массив temperatureSr
            
        }
        
    }
}