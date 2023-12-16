using System;
using System.Collections.Generic;
namespace pr2_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Создаем массив months, в котором будут храняитс яназвания месяцев
            string[] months = new string [12] {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};            
            
            // Создаем словар pogoda, в котором ключом будет - название меясяца, а значением - коллекция (рандомный массив) температур
            Dictionary<string, int[]> pogoda = new Dictionary<string, int[]>();             
            Random rnd = new Random();                        
            /* Используем цикл for в цикле for, для заполнения массива temperature рандомными числами,
             а также для добавления ключа и значений в словарь pogoda */            
            for (int i = 0; i < 12; i++)            
            {                
                int[] temperature = new int[30]; // Создаем массив temperature для хранения в нем случайных чисел
                                                 
                // При каждой новой итерации массив temperature бнуляется
                for (int j = 0; j < temperature.Length; j++)                
                {                    
                    temperature[j] = rnd.Next(-20, 30); // Заполняем массив teemperature случанйми числами в диапазоне от -20 до 30
                }               
                pogoda.Add(months[i], temperature); // Добавляем в словарь ключ (элемент массива months - названние месяца)
                                                    
                // и значение (только что заполненный случайными числами массив temperature)
            }           
            Console.WriteLine("Погода на каждый месяц (в месяце 30 дней):");                                    
            /* Используем цикл в цикле для вывода словаря в консоль.
             foreach нужен для того, чтобы каждый раз проходиться по следующей паре ключ-зачение.            
             for используем для перебора массива внутри словаря, чтобы вывести каждый элемент этого массива */
            foreach (var d in pogoda)
            {
                Console.Write($"{d.Key}: ");
                for (int i = 0; i < d.Value.Length; i++)
                {
                    Console.Write($"  {d.Value[i]};\t");                
                    
                }                
                Console.WriteLine("");
            }           
            Console.WriteLine("\n");            
            Console.WriteLine("Средняя температура за каждый месяц: ");                        
            // Создаем словарь tempSr и сохраняем в него словарь, который возвращает метод Find_Sr_Temp
            Dictionary<string, double> tempSr = Find_Sr_Temp(pogoda);             
            // Используем foreach, чтобы вывести словарь tempSr (вывести в консоль все средние значения температур за каждый месяц)
            foreach (var d in tempSr)
            {
                Console.WriteLine($"За {d.Key} = {d.Value}");
            }        
        }   
        
        // Создаем метод Find_Sr_Temp, который принимает 1 параметр: словарь <ключ типа string, значение типа int[] (массив)>
        public static  Dictionary<string, double> Find_Sr_Temp(Dictionary<string, int[]> dict)        
        {            
            /* Создаем словарь tempSr, который будет хранить в себе: в качестве ключа - название месяца,
             а в качестве значения  - среднюю температуру за этот месяц */            
            Dictionary<string, double> tempSr = new Dictionary<string, double>();
            // Создаем массив months, в котором будут храняитс яназвания месяцев
            string[] months = new string [12] {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};            
            int numberMonth = 0; // Создаем переменную, которая будет отвечать за номер месяца (элемент в массива months)
                                 
            /* Используем цикл в цикле для заполнения словаря tempSr.
             С помощью foreach проходимся по каждой паре ключ-значение в словаре dict (словарь, который передается в параметре).             
             Затем с помощьюк цикла for суммируем все числа в массиве из словаря и считаем среднюю температурау за месяц */            
            foreach (var d in dict)            
            {                
                double sum = 0;
                for (int j = 0; j < d.Value.Length; j++)
                {
                    sum += d.Value[j];
                }               
                double srednee = Math.Round((sum / d.Value.Length),  2); 
                // Считаем среднюю температуру за месяц и округляем до сотых
                tempSr.Add(months[numberMonth], srednee); // Добавляем в словарь tempSr ключ (название месяца - элемент из массива months)
                                                          
                // и значение (Среднюю температуру за месяц)
                numberMonth++ ; // Увеличиваем номер месяца на 1
            }                        
            return tempSr; // Метод возвращает словарь со средними температурными значениями (tempSr)
        }
    }
}