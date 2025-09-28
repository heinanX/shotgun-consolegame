class GamePlay
{
    int round = 0;
    List<(string playerName, string action)> currentMoves = [];

    public static Player SetPlayer()
    {
        Player player = new(Effects.ValidateInput("Enter Player Name:"));
        return player;
    }

    static int GenerateLuck()
    {
        Random rand = new();
        return rand.Next(6);
    }

    public static void FoundSpaceRock(Player player)
    {
        Thread.Sleep(1000);
        Effects.WriteSlow($"{player.playerName} stumbles on a rock.", 50);
        Thread.Sleep(1500);
        Effects.WriteSlow($"... {player.playerName} pockets the rock.", 50);
        player.spaceRock++;
        Thread.Sleep(1000);
    }

    public static void UseSpaceRock(Player player)
    {
        Thread.Sleep(1000);
        Effects.WriteSlow($"{player.playerName} feels a warmth radiating from their pocket.", 50);
        Thread.Sleep(1000);
        Effects.WriteSlow("A wise man's whisper resonates around you", 50);
        Thread.Sleep(1000);
        Effects.WriteSlow($"Use the rock, {player.playerName}~", 150);
        Thread.Sleep(1500);
        Effects.WriteSlow($"... {player.playerName} throws space rock.", 50);
        player.spaceRock--;
        Thread.Sleep(1000);
    }

    void MakeMove(Player player, string action)
    {
        if (player.spaceRock > 0)
        {
            UseSpaceRock(player);
        }
        else
        {
            switch (action)
            {
                case "shoot":
                    player.ShootGun();
                    break;
                case "load":
                    player.LoadGun();
                    break;
                case "block":
                    player.Block();
                    break;
                case "shotgun":
                    player.UseShotGun(player);
                    break;
            }

            player.luck += player.luck + GenerateLuck();
            if (player.luck > 15)
            {
                FoundSpaceRock(player);
            }

            currentMoves.Add((player.playerName, action));
        }
    }

    static bool IsValidAction(string action, int playerShots)
    {
        return action == "block" || action == "load" || (action == "shoot" && playerShots > 0) || (action == "shotgun" && playerShots > 2);
    }

    public void PromptMove(Player player)
    {
        string action = "";
        string msg = player.shots > 2 ? "use shotgun, block or load" : player.shots > 0 ? "shoot, load or block" : "load or block";
        while (!IsValidAction(action, player.shots))
        {
            action = Effects.ValidateInput($"What's your move ({msg}): ").ToLower();
            if (!IsValidAction(action, player.shots)) Console.WriteLine($"You may only {msg}.");
        }
        MakeMove(player, action);
    }
    public void AutomatedMove(Player player)
    {
        List<string> possibleMoves = ["shoot", "block", "load", "shotgun"];
        if (player.shots == 0) possibleMoves.Remove("shoot");
        if (player.shots <= 3) possibleMoves.Remove("shotgun");

        Random rand = new();
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