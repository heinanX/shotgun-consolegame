// int round = 0;
// int activeRoundCount = 0;
int turn = 0;
bool activeGame = true;

Player? player1 = null;
Player player2 = new("Player 2");

while (activeGame && turn < 3)
{
    Methods.SetPlayer(ref player1);

    // player1.LoadStats();
    // Console.WriteLine("");
    // player2.LoadStats();

    if (turn == 0)
    {
        Methods.PromptMove(player1);
        Effects.WriteSlow("...", 150);
        turn++;
    }
    else
    {
        string[] moves = ["shoot", "block", "load"];
        Thread.Sleep(1500);
        Methods.MakeMove(player2, moves[2]); //Add logic for player2 restructure how its done
        turn--;
    }


    // player1.LoadStats();

    // if (player1.life == 0 || player2.life == 0)
    // {
    //     Console.WriteLine("Game over");
    //     Methods.WriteSlow("Would you like to play again?", 50);
    //     Console.WriteLine("yes/no");
    //     if (Console.ReadLine() == "no")
    //     {
    //         activeGame = false;
    //     }


    // }


    // Console.WriteLine(turn);
    // turn++;

    //activeGame = false;
    // player1.FoundSpaceRock();
    // player1.UseSpaceRock();
}