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
        public Dictionary<Guid, LudoGame> LudoGames { get; set; }

        public void AddGame(LudoGame ludoGame)
        {
            Guid g = Guid.NewGuid();
            LudoGames.Add(g, ludoGame);
        }

        public LudoGame GetGame(Guid g)
        {
            // logik
            return null;
        }
    }
}