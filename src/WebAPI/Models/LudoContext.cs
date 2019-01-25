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

        public void AddGame(LudoGame ludoGame)
        {
            Guid g = Guid.NewGuid();
            ludoGames.Add(g, ludoGame);
        }

        public LudoGame GetGame(Guid g)
        {
            // logik
            return null;
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