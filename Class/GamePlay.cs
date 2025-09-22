class GamePlay
{
    int round = 0;
    List<(string playerName, string action)> currentMoves = [];  //check incoming moves


    public void ReadRules()
    {

    }

    public Player SetPlayer(Player? player)
    {
        if (player == null)
        {
            Console.WriteLine("Enter Player Name:");
            player = new Player(Console.ReadLine() ?? "");
        }
        return player;
    }

    void MakeMove(Player player, string action)
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

    public void PromptMove(Player player)
    {
        string action = "";
        while (action != "shoot" && action != "load" && action != "block")
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
    public void AutomatedMove(Player player)
    {
        List<string> possibleMoves = ["shoot", "block", "load"];
        if (player.shots == 0) possibleMoves.Remove("shoot");

        Random rand = new Random();
        Thread.Sleep(1500);
        MakeMove(player, possibleMoves[rand.Next(possibleMoves.Count)]);
    }

    public void CheckRound()
    {

        if (currentMoves.Count == 2)
        {

            // --------------------- del later
            Console.WriteLine("Stats:");
            foreach (var i in currentMoves)
            {
                Console.WriteLine($"{i.playerName}: {i.action}");
            }
            //--------------------------------
            //don't know if clear is the one to use
            currentMoves.Clear();
            Effects.WriteEllipsis();
        }
        // if (currentMoves.Count > 1)
        // {
        //     if ((currentMoves[0].action == "shot") && (currentMoves[1].action == "shoot"))
        //     {
        //         Console.WriteLine("Both players aims their gun, but neither hits.");
        //     } else if ((currentMoves[0].action == "shot") && (currentMoves[1].action == "shoot"))
        // }
    }

    void ReadGameData()
    {
        Console.WriteLine($"Games Played: {round}");
        //Console.WriteLine($"Rounds Won: {round}"); // ADD THIS LATER
    }

    public void IsGameFinished(Player player1, Player player2, ref bool activeGame)
    {
        //Console.WriteLine("checking for game over");
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
            round++;
            ReadGameData();
        }
    }

}