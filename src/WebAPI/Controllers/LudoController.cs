using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LudoGameEngine;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class LudoController : Controller
    {
        public ILudoContext context;
        public LudoController(ILudoContext _context)
        {
            context = _context;
        }

        // POST: api/ludo/createnewgame
        [HttpPost("createnewgame")]
        public void CreateNewGame()
        {
            context.AddGame();
        }

        // GET: api/Ludo
        [HttpGet]
        public Dictionary<Guid, LudoGame> GetAllGames()
        {
            return context.GetAllGames();
        }

        // GET: api/ludo/{gameID}/getgamedetails
        [HttpGet("{id}/getgamedetails")]
        public LudoGame GetGameDetails([FromRoute] Guid id)
        {
            return context.GetGame(id);
        }

        // PUT: api/ludo/{gameID}/movepiece
        [HttpPut("{id}/movepiece")]
        public void MovePiece([FromForm] Guid id, Player player, int pieceId, int numberOfFields)
        {
            context.GetGame(id).MovePiece(player, pieceId, numberOfFields);
        }

        [HttpDelete("{id}/removegame")]
        public void RemoveGame([FromForm] Guid id)
        {
            context.RemoveGame(id);
        }
            
        [HttpGet("{id}/players/getplayers")]
        public Player[] GetPlayers(Guid id)
        {
            return context.GetGame(id).GetPlayers();
        }

        [HttpPost("{id}/players/addplayer")]
        public void AddPlayer(Guid id, string name, int colorID)
        {
            context.GetGame(id).AddPlayer(name, colorID);
        }

        [HttpGet("{id}/players/{PlayerID}")]
        public Player GetPlayerDetails([FromRoute] Guid id, int colorID)
        {
            return context.GetGame(id).GetPlayer(colorID);
        }

        [HttpDelete("{id}/players/{PlayerID}")]
        public void RemovePlayer([FromRoute] Guid id, int colorID)
        {
            context.GetGame(id).RemovePlayer(colorID);
        }
    }
}