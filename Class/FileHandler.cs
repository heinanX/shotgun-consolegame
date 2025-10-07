static class FileHandler
{
    static private string fileName = "rounds.txt";
    // static public void SetFilePath(string path)
    // {
    //fileName = @path;
    // }

    // static public (bool success, List<Round> contacts) ReadRounds()
    // {
    //     List<Round> list = new();
    //     try
    //     {
    //         using (StreamReader reader = new(fileName))
    //         {
    //             string? line;
    //             while ((line = reader.ReadLine()) != null)
    //             {
    //                 ConvertToListItem(list, line);
    //             }
    //             return (true, list);
    //         }
    //     }
    //     catch (Exception exp)
    //     {
    //         Console.Write(exp.Message);
    //         return (false, list);
    //     }
    // }

    // static List<Round> ConvertToListItem(List<Round> list, string listItem)
    // {
    //     var parts = listItem.Split(',');
    //     Round r = new(
    //         int.Parse(parts[0])
    //     );
    //     list.Add(r);
    //     return list;
    // }


    static public bool Write(List<Round> list)
    {
        try
        {
            using (StreamWriter writer = new(fileName))
            {
                writer.WriteLine($"hello");
                foreach (var i in list)
                {
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