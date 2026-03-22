namespace Serwis.Utils;

public static class InputUtils
{
    public static string GetString(string inputLine)
    {
        while (true)
        {
            Console.Write(inputLine);
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) return input;
            
            Console.WriteLine("Blad - pole nie moze byc puste. ");
        }
    }

    public static Guid GetGuid(string prompt)
    {
        Console.Write(prompt);
        if (Guid.TryParse(Console.ReadLine(), out Guid result))
        {
            return result;
        }

        Console.WriteLine("Blad - niepoprawne GUID. ");
        return Guid.Empty;
    }

    public static int GetInt(string prompt)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int result))
        {
            return result;
        }

        Console.WriteLine("Blad - podaj poprawna liczbe! ");
        return -1;
    }

    public static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{message} !");
        Console.ResetColor();
    }
}