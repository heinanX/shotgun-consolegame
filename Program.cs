int playerTurn = 0;
bool activeGame = true;

GamePlay game = new();
Player player1 = GamePlay.SetPlayer();
Player player2 = new("Player 2");

Effects.WriteSlow("Initiating game", 50);
Thread.Sleep(1000);
Effects.WriteSlow($"{player2.playerName} has joined...", 50);
Thread.Sleep(1000);

while (activeGame)
{

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