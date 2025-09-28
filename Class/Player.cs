class Player
{
    public string playerName;
    public int shots;
    public int life;
    //bool ShotGun;
    public int spaceRock;
    public int luck;

    public Player(string _name)
    {
        playerName = _name;
        shots = 0;
        //ShotGun = false;
        spaceRock = 0;
        life = 1;
        luck = 0;
    }

    public bool ShootGun()
    {
        if (shots > 0)
        {
            Console.WriteLine($"{playerName} fires a shot");
            shots--;
            return true;
        }
        else
        {
            Console.WriteLine($"You are out of loads.");
            return false;
        }
    }

    public void UseShotGun(Player player)
    {
        if (player.shots > 2)
        {
            Console.WriteLine($"{playerName} fires their Shotgun");
            //ShotGun = false;
        }
    }

    public void LoadGun()
    {
        Console.WriteLine($"{playerName} loads a bullet.");
        shots++;
    }

    public void Block()
    {
        Console.WriteLine($"{playerName} blocks.");
    }

    public void LoadStats()
    {
        Console.WriteLine($"player: {playerName}");
        Console.WriteLine($"shots: {shots}");
        Console.WriteLine($"life: {life}");
        Console.WriteLine($"spaceRock: {spaceRock}");
    }
}