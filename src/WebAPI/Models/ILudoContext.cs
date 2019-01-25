using LudoGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public interface ILudoContext
    {
        void AddGame(LudoGame ludogame);
        void RemoveGame(Guid id);
        LudoGame GetGame(Guid g);
        Dictionary<Guid, LudoGame> GetAllGames();
    }
}