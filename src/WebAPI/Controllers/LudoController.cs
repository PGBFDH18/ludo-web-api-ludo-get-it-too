using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LudoGameEngine;
using WebAPI.Models;
using Ge = LudoGameEngine;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class LudoController : Controller
    {
        private readonly LudoContext context;

        public LudoController(LudoContext _context)
        {
            context = _context;

            if (context.LudoGames.Count() == 0)
            {
                context.LudoGames.Add(new LudoGame(new Dice()));
                context.SaveChanges();
            }
        }

        // GET: api/Ludo
        [HttpGet]
        public LudoGame[] GetAllGames()
        {
            return context.LudoGames.ToArray();
        }

        // POST: api/ludo/createnewgame
        [HttpPost("createnewgame")]
        public void CreateNewGame()
        {
            context.LudoGames.Add(new LudoGame(new Dice()));
            context.SaveChanges();
        }

        // GET: api/ludo/{gameID}/getgamedetails
        [HttpGet("{id}/getgamedetails")]
        public Piece[] GetGameDetails([FromRoute] long gameID)
        {
            return context.LudoGames.Find(gameID).GetAllPiecesInGame();
        }

        // PUT: api/ludo/{gameID}/movepiece
        [HttpPut("{id}/movepiece")]
        public void MovePiece([FromForm]long gameID, Player player, int pieceId, int numberOfFields)
        {
            context.LudoGames.Find(gameID).MovePiece(player, pieceId, numberOfFields);
            context.SaveChanges();
        }

        [HttpDelete("{id}/removegame")]
        public void RemoveGame()
        {
            // Remove the game in the application layer, db?
        }

        [HttpGet("{id}/players/getplayers")]
        public Player[] GetPlayers([FromRoute] long id)
        {
            Player[] players = context.LudoGames.Find(id).GetPlayers();
            return players;
        }

        [HttpPost("{id}/players/addplayer")]
        public void AddPlayer([FromRoute] long id, string name, int colorID)
        {
            context.LudoGames.Find(id).AddPlayer(name, colorID);
            context.SaveChanges();
        }


        [HttpGet("{id}/players/{PlayerID}")]
        public void GetPlayerDetails([FromRoute] long id, int colorID)
        {
            context.LudoGames.Find(id).GetCurrentPlayer();
            context.SaveChanges();
        }


        [HttpPut("{id}/players/{playerID}")]
        public void ChangePlayerDetails([FromRoute] long id, [FromForm] string playerID, int colorID = 9, string name = "")
        {

            // Request form allows us to extract data from the parameter in the http request.
            // So instead of passing the Player object as a parameter to the function,
            // we can extract the necessary data from the parameter.

            context.LudoGames.Find(id).UpdatePlayer(playerID, colorID, name);
            context.SaveChanges();

        }

        [HttpDelete("{id}/players/{PlayerID}")]
        public void RemovePlayer([FromRoute] long id, int colorID)
        {
            // Remove player where PlayerID matches player,
            // open for suggestions regarding logic behind it.

            //_game.RemovePlayer(color);
        }
        
    }
}
