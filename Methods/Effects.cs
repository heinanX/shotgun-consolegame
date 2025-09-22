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
}