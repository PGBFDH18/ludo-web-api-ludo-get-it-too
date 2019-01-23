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
        public Piece[] GetGameDetails(long id)
        {
            return context.LudoGames.Find(id).GetAllPiecesInGame();
        }


        // PUT: api/ludo/{gameID}/movepiece
        [HttpPut("{id}/movepiece")]
        public void MovePiece(int id, Player player, int pieceId, int numberOfFields)
        {
            context.LudoGames.Find(id).MovePiece(player, pieceId, numberOfFields);
            context.SaveChanges();
        }

        [HttpDelete("{gameID}/removegame")]
        public void RemoveGame()
        {
            // Remove the game in the application layer, db?
        }

        [HttpGet("{gameID}/players/getplayers")]
        public void GetPlayers()
        {
            //return _game.GetPlayers();
        }

        [HttpPut("{gameID}/players/addplayer")]
        public void AddPlayer(string name, PlayerColor color)
        {
            //_game.AddPlayer(name, color);
        }

        [HttpGet("{gameID}/players/{PlayerID}")]
        public void GetPlayerDetails(PlayerColor color)
        {
            // If we assume that PlayerID is the current player :^ )
            // Perhaps take some sort of input from user, such as color.
            // Use this input to find the "right" player.
            //return _game.GetCurrentPlayer();
        }


        [HttpPut("{gameID}/players/{PlayerID}")]
        public Player ChangePlayerDetails(Player p, PlayerColor color, string name = "")
        {

            // Request form allows us to extract data from the parameter in the http request.
            // So instead of passing the Player object as a parameter to the function,
            // we can extract the necessary data from the parameter.
            string tmp = Request.Form["PlayerID"];

            p.PlayerColor = color;
            if(name != "")
            {
                p.Name = name;
            }
            return p;
        }

        [HttpDelete("{GameID}/players/{PlayerID}")]
        public void RemovePlayer(PlayerColor color)
        {
            // Remove player where PlayerID matches player,
            // open for suggestions regarding logic behind it.
            string tmp = Request.Form["PlayerID"];


            //_game.RemovePlayer(color);
        }
        
    }
}
