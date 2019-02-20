using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudoGameEngine
{
    public class LudoGame : ILudoGame
    {
        public IDice dice = null;
        public GameState gameState = GameState.NotStarted;
        public List<Player> players = new List<Player>();
        public int currentPlayerId = 0;

        public LudoGame()
        {
            dice = new Dice();
        }

        public LudoGame(IDice dice)
        {
            this.dice = dice;
        }

        public Player AddPlayer(string name, int colorID)
        {
            PlayerColor color = GetColor(colorID);
            if (gameState != GameState.NotStarted)
            {
                throw new Exception($"Unable to add player since game is {gameState}");
            }

            if (players.Where(p => p.PlayerColor == color).Count() > 0)
            {
                return null;
            }

            Player player = new Player()
            {
                PlayerId = players.Count(),
                Name = name,
                PlayerColor = color,
                Pieces = new Piece[]
                {
                    new Piece{ Position = 0, State = PieceGameState.HomeArea, PieceId = 0, PieceColor=color},
                    new Piece{ Position = 0, State = PieceGameState.HomeArea, PieceId = 1, PieceColor=color},
                    new Piece{ Position = 0, State = PieceGameState.HomeArea, PieceId = 2, PieceColor=color},
                    new Piece{ Position = 0, State = PieceGameState.HomeArea, PieceId = 3, PieceColor=color}
                }
            };

            players.Add(player);

            return player;
        }

        public void EndTurn(Player player)
        {
            if (player.PlayerId != currentPlayerId)
            {
                throw new Exception($"Wrong player, it's currently {currentPlayerId}");
            }

            int numberOfPlayers = players.Count();
            int nextPlayerId = player.PlayerId + 1;


            // currentPlayerId will only update as long as currentDiceRoll isn't 6.
            if (nextPlayerId <= numberOfPlayers - 1 && LastDiceValue() != 6)
            {
                currentPlayerId = nextPlayerId;
            }
            else if(LastDiceValue() != 6)
            {
                currentPlayerId = nextPlayerId - numberOfPlayers;
            }

            // Check for a winner
            foreach (var xplayer in players)
            {
                if (xplayer.Pieces.All(p => p.State == PieceGameState.Goal))
                {
                    gameState = GameState.Ended;
                }
            }
        }

        public Piece[] GetAllPiecesInGame()
        {
            int numberOfPieces = players.Count() * 4;
            Piece[] pieces = new Piece[numberOfPieces];

            int pieceIndex = 0;
            foreach (var player in players)
            {
                foreach (var piece in player.Pieces)
                {
                    pieces[pieceIndex] = piece;
                    pieceIndex++;
                }
            }

            return pieces;
        }

        public PlayerColor GetColor(int colorID)
        {
            if (colorID == 0)
            {
                return PlayerColor.Red;
            }
            if (colorID == 1)
            {
                return PlayerColor.Green;
            }
            if (colorID == 2)
            {
                return PlayerColor.Blue;
            }
            if (colorID == 3)
            {
                return PlayerColor.Yellow;
            }
            else
            {
                return PlayerColor.Red;
            }
        }

        public Player GetCurrentPlayer()
        {
            return players.First(p => p.PlayerId == currentPlayerId);
        }

        public GameState GetGameState()
        {
            return gameState;
        }

        public Player GetPlayer(int colorID)
        {
            return players.Find(c => c.PlayerColor == GetColor(colorID));
        }

        public Player[] GetPlayers()
        {
            return players.ToArray();
        }

        public Player GetWinner()
        {
            foreach (var player in players)
            {
                if (player.Pieces.All(p => p.State == PieceGameState.Goal))
                {
                    gameState = GameState.Ended;
                    return player;
                }
            }
            return null;
        }

        public int LastDiceValue()
        {
            return Dice.LastDiceValue;
        }

        public Piece MovePiece(int pieceId, int numberOfFields)
        {
            if (gameState == GameState.Ended)
            {
                throw new Exception("Game is ended, and a winner is found");
            }

            if (gameState == GameState.NotStarted)
            {
                throw new Exception("Game is not yet started, please start the game");
            }

            var piece = players[currentPlayerId].Pieces[pieceId];

            if (piece.State == PieceGameState.Goal)
            {
                throw new Exception("Piece is in Goal and unable to move");
            }

            var currentPosition = piece.Position;

            if(players[currentPlayerId].Pieces[pieceId].State == 0)
            {
                currentPosition = players[currentPlayerId].Offset;
            }


            var newPosition = currentPosition += numberOfFields;
            piece.State = PieceGameState.InGame;
            piece.Position = newPosition;

            if (newPosition > 31)
            {
                piece.State = PieceGameState.GoalPath;
            }

            if (newPosition > 35)
            {
                piece.State = PieceGameState.Goal;
            }

            return piece;
        }

        public bool RemovePlayer(int colorID)
        {
            bool removed = false;
            foreach (var player in players)
            {
                if (player.PlayerColor == GetColor(colorID) && removed == false)
                {
                    players.Remove(player);
                    removed = true;

                    return removed;
                }
            }

            return removed;
        }

        public int RollDice()
        {
            if (dice == null)
            {
                throw new NullReferenceException("Dice is not set to an instance");
            }

            if (gameState != GameState.Started)
            {
                throw new Exception($"Unable roll dice since the game is not started, it's current state is: {gameState}");
            }

            return dice.RollDice();
        }

        public bool StartGame()
        {
            if (gameState != GameState.NotStarted)
            {
                throw new Exception($"Unable to start game since it has the state {gameState} only NotStarted games can be started");
            }

            if (players.Count < 2)
            {
                throw new Exception("Atleast two players is needed to start the game");
            }

            if (players.Count > 4)
            {
                throw new Exception("A max of four players can be in the game");
            }

            gameState = GameState.Started;
            return true;
        }

        public Player UpdatePlayer(int oldColorID, string name, int colorID)
        {
            Player p1 = players.First(x => x.PlayerId == oldColorID);

            if (p1.PlayerId != 9)
            {
                p1.PlayerColor = GetColor(colorID);
            }
            if (p1.Name != "")
            {
                p1.Name = name;
            }

            return p1;
        }
    }
}