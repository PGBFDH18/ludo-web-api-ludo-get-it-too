using System.Collections.Generic;


namespace LudoGameEngine
{
    public interface ILudoGame
    {
        bool StartGame();
        Player AddPlayer(string name, int colorID);
        Player[] GetPlayers();
        GameState GetGameState();
        //void StartTurn(Player player);

        int RollDice();

        bool RemovePlayer(int colorID);
        Piece MovePiece(int pieceId, int numberOfFields);
        void EndTurn(Player player);

        Player GetCurrentPlayer();
        Piece[] GetAllPiecesInGame();

        Player GetWinner();
    }
}