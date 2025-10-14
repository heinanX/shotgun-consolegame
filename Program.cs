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
    Console.WriteLine("");

    playerTurn = game.PlayTurn(playerTurn, player1, player2);
    if (player2.life == 1)
    {
        playerTurn = game.PlayTurn(playerTurn, player2, player1);
    }

    game.CheckRound();
    game.SaveMoves();

    game.IsGameFinished(player1, player2, ref activeGame);
}