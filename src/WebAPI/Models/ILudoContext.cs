using LudoGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public interface ILudoContext
    {
        Guid AddGame();

        Player AddPlayer(Guid id, string name, int colorID);

        Player ChangePlayerDetails(Guid id, int oldColorID, string name, int colorID);

        void EndTurn(Guid id);

        Dictionary<Guid, LudoGame> GetAllGames();

        Player[] GetAllPlayers(Guid id);

        LudoGame GetGameDetail(Guid id);

        Player GetPlayerDetails(Guid id, int colorID);

        Player GetWinner(Guid id);

        int LastDiceValue(Guid id);

        Piece MovePiece(Guid id, int pieceId, int numberOfFields);

        bool RemoveGame(Guid id);

        bool RemovePlayer(Guid id, int colorID);

        int RollDice(Guid id);

        bool StartGame(Guid id);
    }
}