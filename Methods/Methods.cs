class Methods
{

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

    public static void PromptMove(Player player)
    {
        string action = "";
        while (action == "" && action != "shoot" && action != "load" && action != "block")
        {
            Console.WriteLine($"What's your move (shoot, load, block): ");
            action = Console.ReadLine() ?? "";
            if (action != "shoot" && action != "load" && action != "block") Console.WriteLine("You may only shoot, load, or block.");
        }
        MakeMove(player, action);
    }
    public static void MakeMove(Player player, string action)
    {

        if (action == "shoot")
        {
            player.ShootGun();
        }
        else if (action == "load")
        {
            player.LoadGun();
        }
        else if (action == "block")
        {
            player.Block();
        }
    }

    public static void IsGameFinished(Player player1, Player player2, ref bool activeGame)
    {
        Console.WriteLine("checking for game over");
        if (player1.life == 0 || player2.life == 0)
        {
            Console.WriteLine("Game over");
            Effects.WriteSlow("Would you like to play again?", 50);
            Console.WriteLine("yes/no");
            if (Console.ReadLine() == "no")
            {
                activeGame = false;
            }


        }
    }
}