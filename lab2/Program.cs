using System;
using System.Drawing;

namespace ArrayColoring
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ввод размерности массива с проверкой
            int arraySize = 0;
            while (arraySize <= 0)
            {
                Console.Write("Введите размерность массива: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out arraySize) || arraySize <= 0)
                {
                    Console.WriteLine("Ошибка: введите положительное число.");
                }
            }

            int[] array = new int[arraySize]; // создаем массив заданной размерности
            Random random = new Random(); // инициализируем генератор случайных чисел

            int firstOdd = -1; // индекс первого нечетного числа

            for (int i = 0; i < arraySize; i++) // заполняем массив случайными числами
            {
                array[i] = random.Next(-10, 10);

                if (array[i] % 2 != 0) // если число нечетное
                {
                    if (firstOdd == -1) // если это первое нечетное число
                    {
                        firstOdd = i; // запоминаем его индекс
                    }
                }
            }

            Console.Write("Массив: ");
            // Используем цикл foreach для вывода массива с цветовой выделенной областью
            int index = 0; // Вводим переменную для отслеживания текущего индекса
            foreach (int number in array)
            {
                if (firstOdd != -1) // Если есть нечетное число
                {
                    if (index > firstOdd && number < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
                Console.Write(number + " ");
                Console.ResetColor();
                index++; // Увеличиваем текущий индекс на 1
            }
            Console.WriteLine(); // Переход на новую строку для лучшей читаемости
        }
    }
}