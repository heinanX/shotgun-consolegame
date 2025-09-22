// int round = 0;
// int activeRoundCount = 0;
int turn = 0;
bool activeGame = true;

Player? player1 = null;
Player player2 = new("Player 2");

while (activeGame)
{
    GamePlay.SetPlayer(ref player1);

    // player1.LoadStats();
    // Console.WriteLine("");
    // player2.LoadStats();

    if (turn == 0)
    {
        GamePlay.PromptMove(player1);
        Effects.WriteSlow("...", 150);
        turn++;
    }
    else
    {
        GamePlay.AutomatedMove(player2);
        turn--;
    }


    // player1.LoadStats();

    GamePlay.IsGameFinished(player1, player2, ref activeGame);



    // Console.WriteLine(turn);
    // turn++;

    //activeGame = false;
    // player1.FoundSpaceRock();
    // player1.UseSpaceRock();
}