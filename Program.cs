using System;
using System.Collections.Generic;

class RomanConverter
{
    private static readonly Dictionary<char, int> romanToInt = new Dictionary<char, int>
    {
        {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50},
        {'C', 100}, {'D', 500}, {'M', 1000}
    };

    private static readonly (int value, string symbol)[] intToRoman = new (int, string)[]
    {
        (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
        (100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
        (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")
    };

    // Convierte Romano → Entero
    public static int RomanToInt(string roman)
    {
        int total = 0;
        int prevValue = 0;

        foreach (char c in roman.ToUpper())
        {
            int value = romanToInt[c];
            total += value;

            if (value > prevValue)
            {
                // Restamos dos veces el valor previo (porque ya lo habíamos sumado)
                total -= 2 * prevValue;
            }

            prevValue = value;
        }

        return total;
    }

    // Convierte Entero → Romano
    public static string IntToRoman(int num)
    {
        var result = "";

        foreach (var (value, symbol) in intToRoman)
        {
            while (num >= value)
            {
                result += symbol;
                num -= value;
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Conversor de Romanos ===");
        Console.WriteLine("1. Romano a Entero");
        Console.WriteLine("2. Entero a Romano");
        Console.Write("Elige una opción: ");
        int opcion = int.Parse(Console.ReadLine());

        if (opcion == 1)
        {
            Console.Write("Ingresa un número romano: ");
            string roman = Console.ReadLine();
            int numero = RomanConverter.RomanToInt(roman);
            Console.WriteLine($"El número es: {numero}");
        }
        else if (opcion == 2)
        {
            Console.Write("Ingresa un número entero (1-3999): ");
            int numero = int.Parse(Console.ReadLine());
            string roman = RomanConverter.IntToRoman(numero);
            Console.WriteLine($"El número romano es: {roman}");
        }
        else
        {
            Console.WriteLine("Opción inválida.");
        }
    }
}

