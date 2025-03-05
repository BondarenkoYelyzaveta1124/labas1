
/*2. Дана сукупність n цілих чисел. З’ясувати, чи можна розбити її на пари так, щоб сума
кожної з пар дорівнювала одному й тому самому числу. Якщо можна, то вивести таке
розбиття на пари; якщо не можна — вивести єдину фразу «неможливо», без подальших
пояснень у виведенні програми (але такі пояснення може питати викладач при захисті).*/

using Microsoft.VisualBasic;
using System;
class Program
{
    static void Main()
    {
        Console.Write("Введіть елементи в масив: ");
        string input = Console.ReadLine();

        string[] parts = input.Split();
        int[] numbers = new int[parts.Length];

        for (int i = 0; i < parts.Length; i++)
        {
            if (!int.TryParse(parts[i], out numbers[i]))
            {
                Console.WriteLine("Неможливо");
                return;
            }
        }

        if (numbers.Length % 2 != 0)
        {
            Console.WriteLine("Неможливо");
            return;
        }

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = 0; j < numbers.Length - 1 - i; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Відсортований масив:");
        Console.WriteLine(string.Join(" ", numbers));

        oy(numbers);
    }
    static bool oy(int[] numbers)
    {
        int Sum = numbers[0] + numbers[numbers.Length - 1];

        for (int i = 0; i < numbers.Length / 2; i++)
        {
            if (numbers[i] + numbers[numbers.Length - 1 - i] != Sum)
            {
                return false; 
            }
        }

        Console.WriteLine("Розбиття на пари:");
        for (int i = 0; i < numbers.Length / 2; i++)
        {
            Console.WriteLine($"({numbers[i]}, {numbers[numbers.Length - 1 - i]})");
        }
        return true; 
    }
}
