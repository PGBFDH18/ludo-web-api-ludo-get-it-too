using LudoGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace WebAPI.Models
{
    public class LudoContext : ILudoContext
    {
        public Guid g;
        public Dictionary<Guid, LudoGame> ludoGames;

        public LudoContext()
        {
            ludoGames = new Dictionary<Guid, LudoGame>();
        }

        public Guid AddGame()
        {
            g = Guid.NewGuid();
            ludoGames.Add(g, new LudoGame(new Dice()));
            return g;
        }

        public Player AddPlayer(Guid id, string name, int colorID)
        {
            if (name == null)
            {
                return null;
            }
            return ludoGames[id].AddPlayer(name, colorID);
        }

        public Player ChangePlayerDetails(Guid id, int oldColorID, string name, int colorID)
        {
            return ludoGames[id].UpdatePlayer(oldColorID, name, colorID);
        }

        public void EndTurn(Guid id)
        {
            ludoGames[id].EndTurn(ludoGames[id].GetCurrentPlayer());
        }

        public Dictionary<Guid, LudoGame> GetAllGames()
        {
            return ludoGames;
        }

        public Player[] GetAllPlayers(Guid id)
        {
            return ludoGames[id].GetPlayers();
        }

        public LudoGame GetGameDetail(Guid _id)
        {
            return ludoGames.First(id => id.Key == _id).Value;
        }

        public Player GetPlayerDetails(Guid id, int colorID)
        {
            return ludoGames[id].GetPlayer(colorID);
        }

        public Player GetWinner(Guid id)
        {
            return ludoGames[id].GetWinner();
        }

        public int LastDiceValue(Guid id)
        {
            return ludoGames[id].LastDiceValue();
        }

        public Piece MovePiece(Guid id, int pieceId, int numberOfFields)
        {
            return ludoGames[id].MovePiece(pieceId, numberOfFields);
        }

        public bool RemoveGame(Guid id)
        {
            return ludoGames.Remove(id);
        }

        public bool RemovePlayer(Guid id, int colorID)
        {
            return ludoGames[id].RemovePlayer(colorID);
        }

        public int RollDice(Guid id)
        {
            return ludoGames[id].RollDice();
        }

        public bool StartGame(Guid id)
        {
            return ludoGames[id].StartGame();
        }
    }
}