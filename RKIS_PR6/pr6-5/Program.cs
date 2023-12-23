using System;

namespace pr6_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Получение размера прямоугольной матрицы
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[,] a = new int[n, m];

            // Заполнение матрицы числами 0 и 1
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rnd.Next(2);
                    Console.Write($"{a[i, j]} ");
                }
                Console.Write("\n");
            }

            // Создание нового двумерного массива для добавления еще одного столбца, который делает количество единиц в строке четным
            int[,] new_a = new int[n, m+1];
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    new_a[i, j] = a[i, j]; // Записываем значение элементов матрицы a в марицу new_a
                    if (new_a[i, j] == 1) // Считаем количество единиц в строке
                        count += 1;
                }
                if (count % 2 == 0) // Делаем проверку на четное количество единиц в строке и в последний столбец пишем 0, иначе 1
                    new_a[i, m+1-1] = 0;
                else
                    new_a[i, m+1-1] = 1;
            }
            
            // Вывод матрицы new_a
            Console.WriteLine("Новая матрица: ");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m+1; j++)
                    Console.Write($"{new_a[i, j]} ");
            
            Console.Write("\n");
            
        }
    }
}