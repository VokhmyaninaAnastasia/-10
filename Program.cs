//********************************************
//*Практическая работа №10                   *
//* Выполнила: Вохмянина А.Р., группа 2-ИСП  *
//* Задание: обработка двухмерных массивов   *
//********************************************
using System;

namespace PR_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Практическая работа 10";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            try
            {
                int n = 0;
                double min = 0;
                double max = 0;

                // Ввод размера матрицы
                do
                {
                    Console.Write("Введите размер матрицы (2, 3 или 4): ");

                    if (!int.TryParse(Console.ReadLine(), out n) ||
                        n < 2 || n > 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка! Размер должен быть 2, 3 или 4.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                } while (n < 2 || n > 4);

                // Ввод минимального значения
                do
                {
                    Console.Write("Введите минимальное значение (-10.0): ");

                    if (!double.TryParse(Console.ReadLine(), out min) ||
                        min < -10.0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка! Значение не может быть меньше -10.0.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                } while (min < -10.0);

                // Ввод максимального значения
                do
                {
                    Console.Write("Введите максимальное значение (50.0): ");

                    if (!double.TryParse(Console.ReadLine(), out max) ||
                        max > 50.0 || max <= min)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка! Максимальное значение должно быть не больше 50.0.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                } while (max > 50.0 || max <= min);

                // Создание массива
                double[,] array = new double[n, n];

                Random random = new Random();

                // Заполнение массива
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] =
                            min + random.NextDouble() * (max - min);
                    }
                }

                // Исходная матрица
                Console.WriteLine("Исходная матрица:");

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write($"{array[i, j]:F2}\t");
                    }

                    Console.WriteLine();
                }

                // Транспонирование
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = i + 1; j < array.GetLength(1); j++)
                    {
                        double temp = array[i, j];

                        array[i, j] = array[j, i];

                        array[j, i] = temp;
                    }
                }

                // Транспонированная матрица
                Console.WriteLine("Транспонированная матрица:");

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write($"{array[i, j]}\t");
                    }

                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! Что-то пошло не так !" + ex.Message);

                Console.ForegroundColor = ConsoleColor.White;

            }

        }

    }

}