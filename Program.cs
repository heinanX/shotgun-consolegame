int playerTurn = 0;
bool activeGame = true;

Player? player1 = null;
Player player2 = new("Player 2");
GamePlay game = new();

while (activeGame)
{
    player1 = game.SetPlayer(player1);

    if (playerTurn == 0)
    {
        game.PromptMove(player1);
        Effects.WriteSlow("...", 150);
        playerTurn++;
    }
    else
    {
        game.AutomatedMove(player2);
        playerTurn--;
    }

    game.CheckRound();

    // player1.LoadStats();

    game.IsGameFinished(player1, player2, ref activeGame);



    // Console.WriteLine(playerTurn);
    // playerTurn++;

    //activeGame = false;
    // player1.FoundSpaceRock();
    // player1.UseSpaceRock();
}