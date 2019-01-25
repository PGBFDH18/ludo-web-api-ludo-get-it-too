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
        public Guid g;

        public LudoContext()
        {
            ludoGames = new Dictionary<Guid, LudoGame>();
            g = new Guid();
        }

        public void AddGame()
        {
            ludoGames.Add(g, new LudoGame(new Dice()));
        }

        public LudoGame GetGame(Guid g)
        {
            return ludoGames.First(id => id.Key == g).Value;
        }

        public Dictionary<Guid, LudoGame> GetAllGames()
        {
            return null;
        }

        public void RemoveGame(Guid id)
        {
            ludoGames.Remove(id);
        }
    }
}