using System;

namespace pr2_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Введите размер квадратной матрицы: ");            
            int n = int.Parse(Console.ReadLine()); // Ввод размера n и матрицы matrix
                                                   
            int[,] matrix = new int[n, n]; // Инициализация матрицы matrix размером n*n

            for (int i = 0; i < n; i++) // for и for дла заполнения матрицы
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0) // Если любой из индексов элемента равен 0, то этот элемент равен 1
                    {
                        matrix[i, j] = 1;
                    }
                    else // Иначе все остальные элементы (которые не в первой строке и не в первом столбце)
                    {    // равны сумме верхнего и левого соседних элементов 
                        matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];
                    }
                    Console.Write(matrix[i, j] + "\t"); // Вывод матрицы matrix
                }

                Console.WriteLine("");
            }
        }
    }
}