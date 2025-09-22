class Player
{
    public string playerName;
    public int shots;
    public int life;
    bool ShotGun;
    public int spaceRock;

    public Player(string _name)
    {
        playerName = _name;
        shots = 0;
        ShotGun = false;
        spaceRock = 0;
        life = 1;
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
    public void UseShotGun()
    {
        Console.WriteLine($"{playerName} fires their Shotgun");
        ShotGun = false;
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
    public void FoundSpaceRock()
    {
        Thread.Sleep(1000);
        Effects.WriteSlow($"{playerName} stumbles on a rock.", 50);
        Thread.Sleep(1500);
        Effects.WriteSlow($"... {playerName} pockets the rock.", 50);
        spaceRock++;
        Thread.Sleep(1000);
    }
    public void UseSpaceRock()
    {
        Thread.Sleep(1000);
        Effects.WriteSlow($"{playerName} feels a warmth radiating from their pocket.", 50);
        Thread.Sleep(1000);
        Effects.WriteSlow("A wise man's whisper resonates around you", 50);
        Thread.Sleep(1000);
        Effects.WriteSlow($"Use the rock, {playerName}~", 150);
        Thread.Sleep(1500);
        Effects.WriteSlow($"... {playerName} throws space rock.", 50);
        spaceRock--;
        Thread.Sleep(1000);
    }

    public void LoadStats()
    {
        Console.WriteLine($"player: {playerName}");
        Console.WriteLine($"shots: {shots}");
        Console.WriteLine($"life: {life}");
        Console.WriteLine($"spaceRock: {spaceRock}");
    }


}