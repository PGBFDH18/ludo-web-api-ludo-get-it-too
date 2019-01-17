using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudoGameEngine
{
    public class LudoGame : ILudoGame
    {
        private List<Player> _players = new List<Player>();
        private GameState _gameState = GameState.NotStarted;
        private int currentPlayerId = 0;
        private IDiece _diece = null;

        public LudoGame(IDiece diece)
        {
            _diece = diece;
        }

        public Player AddPlayer(string name, PlayerColor color)
        {
            if (_gameState != GameState.NotStarted)
            {
                throw new Exception($"Unable to add player since game is {_gameState}");
            }

            if (_players.Where(p => p.PlayerColor == color).Count() > 0)
            {
                return null;
            }

            Player player = new Player()
            {
                PlayerId = _players.Count(),
                Name = name,
                PlayerColor = color,
                Pieces = new Piece[]
                {
                    new Piece{ Position = 0, State = PieceGameState.HomeArea, PieceId = 0},
                    new Piece{ Position = 0, State = PieceGameState.HomeArea, PieceId = 1},
                    new Piece{ Position = 0, State = PieceGameState.HomeArea, PieceId = 2},
                    new Piece{ Position = 0, State = PieceGameState.HomeArea, PieceId = 3}
                }
            };

            _players.Add(player);

            return player;
        }

        public void EndTurn(Player player)
        {
            if (player.PlayerId != currentPlayerId)
            {
                throw new Exception($"Wrong player, it's currently {currentPlayerId}");
            }

            int numberOfPlayers = _players.Count();
            int nextPlayerId = player.PlayerId + 1;

            if (nextPlayerId <= numberOfPlayers - 1)
            {
                currentPlayerId = nextPlayerId;
            }
            else
            {
                currentPlayerId = nextPlayerId - numberOfPlayers;
            }

            // Check for a winner
            foreach (var xplayer in _players)
            {
                if (xplayer.Pieces.All(p => p.State == PieceGameState.Goal))
                {
                    _gameState = GameState.Ended;
                }
            }
        }

        public Piece[] GetAllPiecesInGame()
        {
            int numberOfPieces = _players.Count() * 4;
            Piece[] pieces = new Piece[numberOfPieces];

            int pieceIndex = 0;
            foreach (var player in _players)
            {
                foreach (var piece in player.Pieces)
                {
                    pieces[pieceIndex] = piece;
                    pieceIndex++;
                }
            }

            return pieces;
        }

        public Player GetCurrentPlayer()
        {
            return _players.Where(p => p.PlayerId == currentPlayerId).FirstOrDefault();
        }

        public GameState GetGameState()
        {
            return _gameState;
        }

        public Player[] GetPlayers()
        {
            return _players.ToArray();
        }

        public void MovePiece(Player player, int pieceId, int numberOfFields)
        {
            if (_gameState == GameState.Ended)
            {
                throw new Exception("Game is ended, and a winner is found");
            }

            if (_gameState == GameState.NotStarted)
            {
                throw new Exception("Game is not yet started, please start the game");
            }

            var piece = player.Pieces.First(p => p.PieceId == pieceId);

            if (piece.State == PieceGameState.Goal)
            {
                throw new Exception("Piece is in Goal and unable to move");
            }

            var currentPosition = piece.Position;

            var newPosition = currentPosition += numberOfFields;
            piece.State = PieceGameState.InGame;
            piece.Position = newPosition;

            if (newPosition >= 51)
            {
                piece.State = PieceGameState.GoalPath;
            }

            if (newPosition > 55)
            {
                piece.State = PieceGameState.Goal;
            }

        }

        public int RollDiece()
        {
            if (_diece == null)
            {
                throw new NullReferenceException("Diece is not set to an instance");
            }

            if (_gameState != GameState.Started)
            {
                throw new Exception($"Unable roll diece since the game is not started, it's current state is: {_gameState}");
            }

            return _diece.RollDiece();
        }

        public bool StartGame()
        {
            if (_gameState != GameState.NotStarted)
            {
                throw new Exception($"Unable to start game since it has the state {_gameState} only NotStarted games can be started");
            }

            if (_players.Count < 2)
            {
                throw new Exception("Atleast two players is needed to start the game");
            }

            if (_players.Count > 4)
            {
                throw new Exception("A max of four players can be in the game");
            }

            _gameState = GameState.Started;
            return true;
        }

        public Player GetWinner()
        {
            foreach (var player in _players) { 
                if(player.Pieces.All(p => p.State == PieceGameState.Goal))
                {
                    _gameState = GameState.Ended;
                    return player;
                }
            }
            return null;
        }
    }
}
