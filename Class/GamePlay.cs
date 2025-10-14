class GamePlay
{
    List<Round> rounds = [];
    int roundsPlayed = 1;
    int currentRound = 1;
    List<Move> playedMoves = [];

    public static Player SetPlayer()
    {
        Player player = new(Effects.ValidateInput("Enter Player Name:"));
        return player;
    }

    public int PlayTurn(int turn, Player p, Player opponent)
    {
        if (p.meteorite == 1)
        {
            UseSecretMove(p);
            opponent.life = 0;
            return turn;
        }
        else
        {
            if (turn == 0)
            {
                PromptMove(p);
                Effects.WriteSlow("...", 150);
                turn++;
            }
            else
            {
                AutomatedMove(p);
                turn--;
            }
            return turn;
        }

    }
    public void PromptMove(Player player)
    {
        string action = "";
        player.LoadStats();
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
        List<string> possibleMoves = ["block", "load"];
        if (player.shots == 0) { possibleMoves.Remove("shoot"); }
        else
        {
            possibleMoves.Add("shoot");
        }
        if (player.shots <= 3)
        {
            possibleMoves.Remove("shotgun");
        }
        else
        {
            possibleMoves.Add("shotgun");
        }

        Random rand = new();
        Thread.Sleep(1500);
        MakeMove(player, possibleMoves[rand.Next(possibleMoves.Count)]);
    }

    void MakeMove(Player p, string action)
    {
        if (p.meteorite == 1)
        {
            UseSecretMove(p);
        }
        else
        {
            switch (action)
            {
                case "shoot":
                    p.ShootGun(p);
                    break;
                case "load":
                    p.LoadGun(p);
                    break;
                case "block":
                    p.Block(p);
                    break;
                case "shotgun":
                    p.UseShotGun(p);
                    break;
            }
        }
        Move newMove = new(p, action);

        p.luck += GenerateLuck();
        if (p.luck > 15 && action != "shotgun")
        {
            Foundmeteorite(p);
        }

        playedMoves.Add(newMove);
    }

    public void SaveMoves()
    {
        FileHandler.Write(rounds);
    }


    static int GenerateLuck()
    {
        Random rand = new();
        return rand.Next(6);
    }

    public static void Foundmeteorite(Player player)
    {
        Thread.Sleep(1000);
        Effects.WriteSlow($"{player.playerName} stumbles on a rock.", 50);
        Thread.Sleep(1500);
        Effects.WriteSlow($"... {player.playerName} pockets the rock.", 50);
        player.meteorite++;
        Thread.Sleep(1000);
    }

    public static void UseSecretMove(Player p)
    {
        Thread.Sleep(1000);
        Effects.WriteSlow($"{p.playerName} feels a warmth radiating from their pocket.", 50);
        Thread.Sleep(1000);
        Effects.WriteSlow("A wise man's whisper resonates", 50);
        Thread.Sleep(1000);
        Effects.WriteSlow($"Use the force... err... meteorite , {p.playerName}~", 150);
        Thread.Sleep(1500);
        Effects.WriteSlow($"... {p.playerName} throws meteorite.", 50);
        p.meteorite--;
        Thread.Sleep(1000);
    }


    static bool IsValidAction(string action, int playerShots)
    {
        return action == "block" || action == "load" || (action == "shoot" && playerShots > 0) || (action == "shotgun" && playerShots > 2);
    }



    public void CheckRound()
    {

        if (playedMoves.Count == 2)
        {
            string result = GameLogic.CompareMoves(playedMoves[0], playedMoves[1]);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(result);
            Console.ResetColor();
            Console.WriteLine("");

            Round newRound = new(roundsPlayed, currentRound, playedMoves[0], playedMoves[1]);
            rounds.Add(newRound);
            currentRound++;
            playedMoves.Clear();
            Console.WriteLine($"------- Round: {currentRound}");
        }
    }

    public void IsGameFinished(Player player1, Player player2, ref bool activeGame)
    {
        if (player1.life == 0 || player2.life == 0)
        {
            Console.WriteLine(player1.life == 0 ? $"Better luck next time!" : $"{player1.playerName} obliterated their opponent!");
            Console.WriteLine("Game over");
            Effects.WriteSlow("Would you like to play again?", 50);
            Console.WriteLine("yes/no");
            if (Console.ReadLine() != "yes")
            {
                activeGame = false;
            }
            player1.resetPlayerStats();
            player2.resetPlayerStats();
            roundsPlayed++;
            currentRound = 1;
        }
    }

}