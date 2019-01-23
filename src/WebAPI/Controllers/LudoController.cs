using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LudoGameEngine;
using WebAPI.Models;
using Ge = LudoGameEngine;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LudoController : ControllerBase
    {
        private ILudoGame _game;
        public LudoController(Ge.ILudoGame ge)
        {
            _game = ge;
        }

        // GET api/ludo
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    var game = new LudoGame(new Dice());
        //    game.AddPlayer("player1", PlayerColor.Blue);
        //    game.AddPlayer("player2", PlayerColor.Red);

        //    var players = game.GetPlayers();
        //    return players.Select(p => p.Name).ToArray();
        //}

        // POST api/ludo/createnewgame
        [HttpPost("createnewgame")]
        public void CreateNewGame()
        {
            _game.StartGame();
        }

        [HttpGet("{gameID}/getgamedetails")]
        public Piece[] GetGameDetails()
        {
            return _game.GetAllPiecesInGame();
        }

        [HttpPut("{gameID}/movepiece")]
        public void MovePiece(Piece piece, int pieceId, int steps)
        {
            // Move the selected piece
        }

        [HttpDelete("{gameID}/removegame")]
        public void RemoveGame()
        {
            // Remove the game in the application layer, db?
        }

        [HttpGet("{gameID}/players/getplayers")]
        public Player[] GetPlayers()
        {
            return _game.GetPlayers();
        }

        [HttpPut("{gameID}/players/addplayer")]
        public void AddPlayer(string name, PlayerColor color)
        {
            _game.AddPlayer(name, color);
        }

        [HttpGet("{gameID}/players/{PlayerID}")]
        public Player GetPlayerDetails(PlayerColor color)
        {
            // If we assume that PlayerID is the current player :^ )
            // Perhaps take some sort of input from user, such as color.
            // Use this input to find the "right" player.
            return _game.GetCurrentPlayer();
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


            _game.RemovePlayer(color);
        }
    }
}