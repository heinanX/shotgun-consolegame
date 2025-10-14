static class FileHandler
{
    static private string fileName = "rounds.txt";

    static public bool Write(List<Round> list)
    {
        try
        {
            using (StreamWriter writer = new(fileName))
            {
                foreach (var i in list)
                {
                    writer.WriteLine($"{i.roundsPlayed}");
                    writer.WriteLine($"{i.round}");
                    writer.WriteLine($"{i.p1Moves.actionString}");
                    writer.WriteLine($"{i.p2Moves.actionString}");
                }
                return true;
            }
        }
        catch (Exception exp)
        {
            Console.Write(exp.Message);
            return false;
        }
    }
}