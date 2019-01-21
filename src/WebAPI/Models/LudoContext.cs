using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace WebAPI.Models
{
    public class LudoContext
    {
        private List<Ludo> ludoGames = new List<Ludo>();

        public LudoContext()
        {
            ludoGames.Add(new Ludo((ludoGames.Count + 1), new LudoGameEngine.LudoGame(new LudoGameEngine.Dice())));
        }
        
        public List<Ludo> GetAllGames()
        {
            return ludoGames;
        }

    }
}
