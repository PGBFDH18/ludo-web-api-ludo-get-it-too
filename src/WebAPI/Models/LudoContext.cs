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
        public Dictionary<Guid, LudoGame> ludoGames;
        public LudoContext()
        {
            ludoGames = new Dictionary<Guid, LudoGame>();
        }

        public void AddGame()
        {
            ludoGames.Add(Guid.NewGuid(), new LudoGame(new Dice()));
        }

        public LudoGame GetGame(Guid g)
        {
            return ludoGames.First(id => id.Key == g).Value;
        }

        public Dictionary<Guid, LudoGame> GetAllGames()
        {
            return ludoGames;
        }

        public void RemoveGame(Guid id)
        {
            ludoGames.Remove(id);
        }
    }
}