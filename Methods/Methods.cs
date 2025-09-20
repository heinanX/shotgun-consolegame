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
}