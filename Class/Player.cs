public class Player
{
    public string playerName;
    public int shots;
    public int life;
    public bool shotgun;
    public int meteorite;
    public int luck;

    public Player(string _name)
    {
        playerName = _name;
        shots = 0;
        shotgun = false;
        meteorite = 0;
        life = 1;
        luck = 0;
    }

    public void ShootGun(Player p)
    {
        Console.WriteLine($"{p.playerName} fires a shot");
        shots--;
    }

    public void UseShotGun(Player p)
    {
        Console.WriteLine($"{p.playerName} fires their Shotgun");
        shotgun = false;
    }

    public void LoadGun(Player p)
    {
        Console.WriteLine($"{p.playerName} loads a bullet.");
        shots++;
        if (shots == 3)
        {
            shotgun = true;
        }
    }

    public void Block(Player p)
    {
        Console.WriteLine($"{p.playerName} blocks.");
    }

    public void playerDeath()
    {
        life = 0;
    }

    public void LoadStats()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Player {playerName} stats:");
        Console.WriteLine($"shots: {shots}, Shotgun: {shotgun}, life: {life}, meteorite: {meteorite}, luck: {luck}");
        Console.ResetColor();
    }

    public void resetPlayerStats()
    {
        shots = 0;
        shotgun = false;
        life = 1;
        luck = 0;
        meteorite = 0;
    }
}