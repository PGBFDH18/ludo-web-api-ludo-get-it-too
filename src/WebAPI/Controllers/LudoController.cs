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
        private readonly LudoContext context;
        public LudoController(LudoContext _context)
        {
            context = _context;
        }

        // POST: api/ludo/createnewgame
        [HttpPost("createnewgame")]
        public void CreateNewGame()
        {
            context.AddGame(new LudoGame(new Dice()));
        }

        // GET: api/Ludo
        [HttpGet]
        public LudoGame[] GetAllGames()
        {
            return null;
        }

        // GET: api/ludo/{gameID}/getgamedetails
        /*[HttpGet("{gameID}/getgamedetails")]
        public Piece[] GetGameDetails([FromRoute] long gameID)
        {
            //return context.LudoGames.Find(gameID).GetAllPiecesInGame();
        }*/

        // PUT: api/ludo/{gameID}/movepiece
        [HttpPut("{id}/movepiece")]
        public void MovePiece([FromForm]long id, Player player, int pieceId, int numberOfFields)
        {
            //context.LudoGames.Find(id).MovePiece(player, pieceId, numberOfFields);
        }

        [HttpDelete("{id}/removegame")]
        public void RemoveGame()
        {
            //context.LudoGames.Find(gameID).GetCurrentPlayer();
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
            // Remove player where PlayerID matches player,
            // open for suggestions regarding logic behind it.

            //_game.RemovePlayer(color);
        }
    }
}