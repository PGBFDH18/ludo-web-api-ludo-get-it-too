using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoGameEngine;

namespace WebAPI.Models
{
    public class Ludo
    {
        public int Id { get; set; }
        public LudoGame Game { get; set; }

        public Ludo(int id, LudoGame game)
        {
            Id = id;
            Game = game;
        }
    }
}
