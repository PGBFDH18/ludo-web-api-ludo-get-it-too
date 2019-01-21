using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LudoGameEngine;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LudoController : ControllerBase
    {
        // GET DICK
        [HttpGet("MONA")]
        public string get()
        {
            return Test.MonaLisa();
        }

        // GET api/ludo
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var game = new LudoGame(new Dice());
            game.AddPlayer("player1", PlayerColor.Blue);
            game.AddPlayer("player2", PlayerColor.Red);

            var players = game.GetPlayers();
            return players.Select(p => p.Name).ToArray();
        }

        // POST api/ludo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        LudoGame game = new LudoGame(new Dice());

        // POST api/ludo/createnewgame
        [HttpPost("createnewgame")]
        public void CreateNewGame()
        {
            if (false)
            {
                throw new Exception("no.");
            }
            else
            {
                game.StartGame();
            }
        }

        [HttpGet("{gameID}/getgamedetails")]
        public Piece[] GetGameDetails()
        {
            return game.GetAllPiecesInGame();
        }

        [HttpPut("{gameID}/movepiece")]
        public void MovePiece(Piece piece)
        {
            // Move the selected piece
        }

        [HttpDelete("{gameID}/removegame")]
        public void RemoveGame()
        {
            // Remove the game in the application layer
        }

        [HttpGet("{gameID}/players/getplayers")]
        public Player[] GetPlayers()
        {
            return game.GetPlayers();
        }

        [HttpPut("{gameID}/players/addplayer")]
        public void AddPlayer(string name, PlayerColor color)
        {
            game.AddPlayer(name, color);
        }

        [HttpGet("{gameID}/players/{PlayerID}")]
        public Player GetPlayerDetails(PlayerColor color)
        {
            // If we assume that PlayerID is the current player :^ )
            // Perhaps take some sort of input from user, such as color.
            // Use this input to find the "right" player.
            return game.GetCurrentPlayer();
        }


        [HttpPut("{gameID}/players/{PlayerID}")]
        public Player ChangePlayerDetails(Player p, PlayerColor color, string name = "")
        {
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
            game.RemovePlayer(color);
        }

    }
}