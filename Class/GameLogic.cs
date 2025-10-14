static class GameLogic
{
    static public Dictionary<(string, string), int> possibleOutcomes = new()
{
    { ("block", "block"), 0 },
    { ("shoot", "block"), 0 },
    { ("block", "shoot"), 0 },
    { ("shoot", "shoot"), 0 },
    { ("load", "load"), 0 },
    { ("load", "shoot"), 2 },
    { ("load", "block"), 0 },
    { ("shoot", "load"), 1 },
    { ("block", "load"), 0 },
    { ("shotgun", "load"), 1 },
    { ("shotgun", "block"), 1 },
    { ("shotgun", "shoot"), 1 },
    { ("shoot", "shotgun"), 2 },
    { ("block", "shotgun"), 2 },
    { ("load", "shotgun"), 2 },
    { ("shotgun", "shotgun"), 0 },
};

    static public string CompareMoves(Move move1, Move move2)
    {
        var result = possibleOutcomes[(move1.actionString, move2.actionString)];
        if (result == 1)
        {
            move2.p.playerDeath();
            return $"{move1.p.playerName} won";
        }
        else if (result == 2)
        {
            move1.p.playerDeath();
            return $"{move2.p.playerName} won";
        }
        else
        {
            if (move1.actionString == "block" && move2.actionString == "shoot")
            {
                return $"{move1.p.playerName} narrowly escaped";
            }
            else if (move2.actionString == "block" && move1.actionString == "shoot")
            {
                return $"{move2.p.playerName} narrowly escaped";
            }
            else
            {
                return "nothing happens";
            }
        }
    }



}