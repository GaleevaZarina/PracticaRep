using System;

namespace pr2_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] temperature = new int[12, 30]; // Создаем двумерный массив, в котором будет хранитя температура каждого месяца (на 30 дней каждого месяца)

            Random rnd = new Random();

            for (int i = 0;
                 i < 12;
                 i++) // for в for для заполнения двумерного массива temperature рандомным числами        
            {
                Console.Write($"{i + 1} месяц:  "); // Для удобства выводим номер месяца
                for (int j = 0; j < 30; j++)
                {
                    temperature[i, j] = rnd.Next(-20, 30); // Температура будет в диапазоне от -20 до 30
                    Console.Write(temperature[i, j] + "  "); // Сразу выводим двумерный массив
                }

                Console.WriteLine(""); // Переход на новую строку
            }

            Console.WriteLine("\nСредняя температура каждого месяца: ");
            double[]
                temperatureSr =
                    FindSrTemp(temperature); // Создаем массив temperatureSr, в который сохраним среднюю температуру каждого месяца            
            // Присваиваем массиву temperatureSr значение, которое возвращает метод FindSrTemp           

            foreach (double item in
                     temperatureSr) // foreach выводит массив temperatureSr (выводим среднюю температуру за каждый месяц)
                Console.Write(item + ";  ");

            Array.Sort(temperatureSr); // Сортируем массив temperatureSr по возрастанию
            Array.Reverse(temperatureSr); // Переворачиваем массив temperatureSr

            Console.WriteLine("\nТемпература отсортирована по убыванию: ");

            foreach (double item in temperatureSr) // foreach выводит массив temperatureSr отсортированный по убыванию
                Console.Write(item + ";  ");
        }


        /* Создаем метод FindSrTemp для поиска средней температуры каждого месяца.
         Метод принимает 1 параметр: двумерный массив с температурами; Метод возвращает массив со средними температурами */
        public static double[] FindSrTemp(int[,] array)
        {
            double[]
                temperatureSr =
                    new double [12]; // Создаем массив temperatureSr, в который будем записывать найденную среднюю температуру

            for (int i = 0;
                 i < 12;
                 i++) // for в for для вычисления средней температуры в каждом месяце и ее записи в массив temperatureSr
            {
                double
                    sum = 0; // Создаем переменную sum для подсчета суммы температуры за весь месяц (нужно, чтоы посчитать среднюю)
                for (int j = 0; j < 30; j++)
                {
                    sum += array[i, j]; // Суммируем все значения в строке

                }

                temperatureSr[i] =
                    Math.Round((sum / 30),
                        2); // Находим среднюю температуру за месяц и присваиваем это значение элементу массива temperatureSr
            }

            return temperatureSr; // Метод возвращает массив temperatureSr
        }

    }
}