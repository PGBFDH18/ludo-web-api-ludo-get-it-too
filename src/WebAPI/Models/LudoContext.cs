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
        public long id { get; set; }
        public List<LudoGame> LudoGames { get; set; }

        public void AddGame()
        {
            
        }
    }
}
