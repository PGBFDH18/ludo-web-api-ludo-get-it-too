using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LudoGameEngine;
using WebAPI.Models;
using System.Collections.Specialized;
using System.Net;

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

        // Weird attempt to extract the ID which a game is assigned upon creation.
        public string SetNewUrl(Guid g)
        {
            var url = this.Url.Link($"https://localhost:5001/api/ludo/{0}", g);
            return url;
        }

        // POST: api/ludo/createnewgame
        [HttpPost("createnewgame")]
        public IActionResult CreateNewGame()
        {
            // Reason why AddGame returns a Guid object is so we can use the created games ID,
            // and append it to the URL ex. api/ludo/{gameId}
            Guid g = context.AddGame();
            return Ok(g);
            //Response.Redirect(SetNewUrl(g), true);
        }

        // DELETE: api/ludo/{gameID}/removegame
        [HttpDelete("{id}/removegame")]
        public IActionResult RemoveGame(Guid id)
        {
            if (!context.RemoveGame(id))
            {
                return NotFound(id);
            }
            else
            {
                return Ok();
            }
        }

        // POST: api/ludo/{gameID}/players/addplayer?name={input}&colorID={input}
        [HttpPost("{id}/players/addplayer")]
        public IActionResult AddPlayer(Guid id, string name, int colorID)
        {
            if (context.AddPlayer(id, name, colorID) == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(context.GetGameDetail(id).GetPlayer(colorID));
            }
        }

        [HttpDelete("{id}/players")]
        public IActionResult RemovePlayer(Guid id, int colorID)
        {
            if(!context.RemovePlayer(id, colorID))
            {
                return NotFound(new KeyValuePair<Guid, int>(id, colorID));
            }

            return Ok(new KeyValuePair<Guid, int>(id, colorID));
        }

        // GET: api/Ludo/getallgames
        [HttpGet("getallgames")]
        public IActionResult GetAllGames()
        {
            return Ok(context.GetAllGames());
        }

        // GET: api/ludo/{gameID}/getgamedetails
        [HttpGet("{id}/getgamedetails")]
        public IActionResult GetGameDetails(Guid id)
        {
            if(context.GetGameDetail(id) == null)
            {
                return NotFound(id);
            }

            return Ok(context.GetGameDetail(id));
        }

        // GET: api/ludo/{gameID}/players/getplayers
        [HttpGet("{id}/players/getplayers")]
        public IActionResult GetAllPlayers(Guid id)
        {
            if(context.GetAllPlayers(id) == null)
            {
                return NotFound(id);
            }

            return Ok(context.GetAllPlayers(id));
        }

        // GET: api/ludo/{gameID}/players?colorID={input}
        [HttpGet("{id}/players")]
        public IActionResult GetPlayerDetails(Guid id, int colorID)
        {
            if(context.GetPlayerDetail(id, colorID) == null)
            {
                return NotFound(id);
            }

            return Ok(context.GetPlayerDetail(id, colorID));
        }

        // PUT: api/ludo/{gameID}/movepiece
        [HttpPut("{id}/movepiece")]
        public void MovePiece(Guid id, Player player, int pieceId, int numberOfFields)
        {
            context.GetGameDetail(id).MovePiece(player, pieceId, numberOfFields);
        }

        
    }
}