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
        bool RemoveGame(Guid id);
        LudoGame GetGame(Guid id);
        Player GetPlayerDetail(Guid id, int ColorID);
        Player AddPlayer(Guid id, string name, int colorID);
        Dictionary<Guid, LudoGame> GetAllGames();
    }
}