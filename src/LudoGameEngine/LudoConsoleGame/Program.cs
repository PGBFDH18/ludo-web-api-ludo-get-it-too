using LudoGameEngine;
using System;

namespace LudoConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ludo");
            var ludoGame = new LudoGame(new Diece());
            AddPlayers(ludoGame);
            var gameIsStarted = ludoGame.StartGame();
            if (!gameIsStarted)
            {
                Console.WriteLine("Game NOT started");
                Console.Write("Press any key to exit!");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
            Console.WriteLine("Game started");
            do
            {
                Console.WriteLine();
                var currentPlayer = ludoGame.GetCurrentPlayer();
                Console.WriteLine($"Current player is {currentPlayer.Name}");
                var dieceResult = ludoGame.RollDiece();
                Console.WriteLine($"Diece roll gave: {dieceResult}");
                Console.WriteLine("Choose which piece to move:");
                foreach (var piece in currentPlayer.Pieces) {
                    if (piece.State == PieceGameState.Goal)
                    {
                        continue;
                    }

                    Console.WriteLine($"{piece.PieceId}. located in {piece.State} at {piece.Position}");
                    
                }
                var pieceNr = Console.ReadLine();
                int.TryParse(pieceNr, out int pieceIdToMove);
                ludoGame.MovePiece(currentPlayer, pieceIdToMove, dieceResult);
                ludoGame.EndTurn(currentPlayer);
            } while (ludoGame.GetWinner() == null);

            Console.WriteLine($"{ludoGame.GetWinner().Name} is the winner!!!");

            Console.Write("Press any key to exit!");
            Console.ReadKey();
        }

        static void AddPlayers(LudoGame ludoGame)
        {
            Player latestPlayer = null;
            do
            {
                Console.WriteLine("Choose color:");
                Console.WriteLine("0. Red");
                Console.WriteLine("1. Green");
                Console.WriteLine("2. Blue");
                Console.WriteLine("3. Yellow");
                Console.Write("Enter number (press enter to skip) :");
                var color = Console.ReadLine();
                if (string.IsNullOrEmpty(color))
                {
                    return;
                }
                int.TryParse(color, out int colorNumber);

                Console.Write("Enter playername :");
                var playername = Console.ReadLine();

                latestPlayer = ludoGame.AddPlayer(playername, (PlayerColor)colorNumber);
                if (latestPlayer == null)
                {
                    Console.WriteLine("Unable to add player");
                }
            } while (latestPlayer != null);
        }
    }
}
