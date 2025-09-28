class Effects
{
    public static void WriteSlow(string text, int delay)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }

    public static void WriteEllipsis()
    {
        WriteSlow("...", 150);
    }

    public static string ValidateInput(string msg)
    {
        string input = "";
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine($"{msg}");
            input = Console.ReadLine() ?? "";
        }
        return input;
    }
}