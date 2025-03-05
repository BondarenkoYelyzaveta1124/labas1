using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть елементи в масив: ");
        string input = Console.ReadLine();

        string[] parts = input.Split();
        int[] numbers = new int[parts.Length];

        if (vvod(numbers, parts))
        {
            sort(numbers);
            sum(numbers);
        }
    }

    static bool vvod(int[] numbers, string[] parts)
    {
        for (int i = 0; i < parts.Length; i++)
        {
            if (!int.TryParse(parts[i], out numbers[i]))
            {
                Console.WriteLine("Неможливо");
                return false; 
            }
        }

        if (numbers.Length % 2 != 0)
        {
            Console.WriteLine("Неможливо");
            return false; 
        }
        return true; 
    }

    static void sort(int[] numbers)
    {
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
    }

    static bool sum(int[] numbers)
    {
        int targetSum = numbers[0] + numbers[numbers.Length - 1];

        for (int i = 0; i < numbers.Length / 2; i++)
        {
            if (numbers[i] + numbers[numbers.Length - 1 - i] != targetSum)
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
