using System;
using System.Collections.Generic;
namespace pr2_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Создаем массив months с названиями месяцев
            string[] months = new string [12] {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};            
            
            Dictionary<string, int[]> pogoda = new Dictionary<string, int[]>(); // Создаем словарь pogoda { ключ - название меясяца, значение - коллекция (рандомный массив) температур}            
            Random rnd = new Random();
            
            for (int i = 0; i < 12; i++) // for в for для заполнения массива temperature рандомными числами, и добавления ключа и значений в словарь pogoda
            {                
                int[] temperature = new int[30]; // Массив temperature для хранения в нем случайных чисел
                                                 // При каждой новой итерации массив temperature бнуляется
                for (int j = 0; j < temperature.Length; j++)              
                {                    
                    temperature[j] = rnd.Next(-20, 30); // Заполняем массив temperature случанйми числами в диапазоне от -20 до 30
                }               
                pogoda.Add(months[i], temperature); // Добавляем в словарь ключ (элемент массива months - названние месяца) и значение (только что заполненный случайными числами массив temperature)
               
            }           
            Console.WriteLine("Погода на каждый месяц (в месяце 30 дней):");                                    
            
            // foreach в for вывода словаря в консоль
            foreach (var d in pogoda) // foreach нужен для того, чтобы каждый раз проходиться по следующей паре ключ-зачение
            {
                Console.Write($"{d.Key}: "); // вывод месяца
                for (int i = 0; i < d.Value.Length; i++) // for для перебора массива внутри словаря и вывода каждого элемента этого массива
                {
                    Console.Write($"  {d.Value[i]};\t"); // вывод температур для данного месяца        
                    
                }                
                Console.WriteLine("");
            }           
                     
            Console.WriteLine("\nСредняя температура за каждый месяц: ");                        
            
            Dictionary<string, double> tempSr = Find_Sr_Temp(pogoda); // В словарь tempSr сохраняем в словарь, который возвращает метод Find_Sr_Temp     
            
            foreach (var d in tempSr) // foreach, для вывода словаря tempSr (вывод в консоль все средние значения температур за каждый месяц)
                Console.WriteLine($"За {d.Key} = {d.Value}");
        }   
        
        // Создаем метод Find_Sr_Temp, который принимает 1 параметр: словарь <ключ типа string, значение типа int[] (массив)>
        public static  Dictionary<string, double> Find_Sr_Temp(Dictionary<string, int[]> dict)        
        {
            Dictionary<string, double> tempSr = new Dictionary<string, double>(); // Создаем словарь tempSr { ключ - название меясяца, значение - среднюю температуру за этот месяц}  
            
            // Создаем массив months с названиями месяцев
            string[] months = new string [12] {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};            
            int numberMonth = 0; // Создаем переменную, которая будет отвечать за номер месяца (элемент в массива months)
            
            foreach (var d in dict) // foreach для прохода по каждой паре ключ-значение в словаре dict (словарь, который передается в параметре)
            {                
                double sum = 0;
                for (int j = 0; j < d.Value.Length; j++) // for для суммирования всех чисел в массиве из словаря, и для подсчета средней температуры за месяц
                {
                    sum += d.Value[j];
                }               
                double srednee = Math.Round((sum / d.Value.Length),  2); // Считаем среднюю температуру за месяц и округляем до сотых
                tempSr.Add(months[numberMonth], srednee); // Добавляем в словарь tempSr ключ (название месяца - элемент из массива months) и значение (Среднюю температуру за месяц)
                numberMonth++ ; // Увеличиваем номер месяца на 1
            }                        
            return tempSr; // Метод возвращает словарь со средними температурными значениями (tempSr)
        }
    }
}