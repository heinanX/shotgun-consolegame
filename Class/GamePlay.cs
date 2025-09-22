class GamePlay
{
    // int round = 0;
    // int activeRoundCount = 0;
    static List<(string playerName, string action)> currentMoves = [];  //check incoming moves


    public static void ReadRules()
    {

    }

    public static void SetPlayer(ref Player player)
    {
        if (player == null)
        {
            Console.WriteLine("Enter Player Name:");
            player = new Player(Console.ReadLine() ?? "");
        }
        return;
    }

    static void MakeMove(Player player, string action)
    {
        if (action.ToLower() == "shoot")
        {
            player.ShootGun();
        }
        else if (action.ToLower() == "load")
        {
            player.LoadGun();
        }
        else if (action.ToLower() == "block")
        {
            player.Block();
        }
        currentMoves.Add((player.playerName, action));
    }

    public static void PromptMove(Player player)
    {
        string action = "";
        while (action == "" && action != "shoot" && action != "load" && action != "block")
        {
            if (player.shots > 0)
            {
                Console.WriteLine($"What's your move (shoot, load or block): ");
            }
            else
            {
                Console.WriteLine($"What's your move (load or block): ");
            }
            action = Console.ReadLine() ?? "";
            if (action != "shoot" && action != "load" && action != "block") Console.WriteLine("You may only shoot, load, or block.");
        }
        MakeMove(player, action);
    }
    public static void AutomatedMove(Player player)
    {
        List<string> moves = ["shoot", "block", "load"];
        if (player.shots == 0) moves.Remove("shoot");
        Random rand = new Random();
        Thread.Sleep(1500);
        MakeMove(player, moves[rand.Next(moves.Count)]);
    }

    static void CheckRound()
    {
        foreach (var i in currentMoves)
        {
            Console.WriteLine(i);
        }
        if (currentMoves.Count == 2)
        {
            currentMoves.Clear();
        }
        // if (currentMoves.Count > 1)
        // {
        //     if ((currentMoves[0].action == "shot") && (currentMoves[1].action == "shoot"))
        //     {
        //         Console.WriteLine("Both players aims their gun, but neither hits.");
        //     } else if ((currentMoves[0].action == "shot") && (currentMoves[1].action == "shoot"))
        // }
    }

    public static void IsGameFinished(Player player1, Player player2, ref bool activeGame)
    {
        CheckRound();
        Console.WriteLine("checking for game over");
        if (player1.life == 0 || player2.life == 0)
        {
            Console.WriteLine("Game over");
            Console.WriteLine(player1.life == 0 ? $"{player2} won the game." : $"{player1} obliterated their opponent!");
            Effects.WriteSlow("Would you like to play again?", 50);
            Console.WriteLine("yes/no");
            if (Console.ReadLine() == "no")
            {
                activeGame = false;
            }
        }
    }
}