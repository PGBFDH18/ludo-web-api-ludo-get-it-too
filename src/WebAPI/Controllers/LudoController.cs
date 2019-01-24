﻿using System;
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
        [HttpGet("{gameID}/getgamedetails")]
        public Piece[] GetGameDetails([FromRoute] long gameID)
        {
            return context.LudoGames.Find(gameID).GetAllPiecesInGame();
        }

        // PUT: api/ludo/{gameID}/movepiece
        [HttpPut("{gameID}/movepiece")]
        public void MovePiece([FromForm]long gameID, Player player, int pieceId, int numberOfFields)
        {
            context.LudoGames.Find(gameID).MovePiece(player, pieceId, numberOfFields);
            context.SaveChanges();
        }

        [HttpDelete("{gameID}/removegame")]
        public void RemoveGame()
        {
            // Remove the game in the application layer, db?
        }

        [HttpGet("{gameID}/players/getplayers")]
        public void GetPlayers([FromRoute] string gameID)
        {
            context.LudoGames.Find(long.Parse(gameID)).GetPlayers();
            context.SaveChanges();

        }

        [HttpPost("{gameID}/players/addplayer")]
        public void AddPlayer([FromRoute]string gameID, string name, int colorID)
        {

            context.LudoGames.Find(long.Parse(gameID)).AddPlayer(name, colorID);
            context.SaveChanges();

        }

        [HttpGet("{gameID}/players/{PlayerID}")]
        public void GetPlayerDetails([FromRoute] string gameID, int colorID)
        {
            context.LudoGames.Find(long.Parse(gameID)).GetCurrentPlayer();
            context.SaveChanges();

        }


        [HttpPut("{gameID}/players/{playerID}")]
        public void ChangePlayerDetails([FromRoute] string gameID, [FromForm] string playerID, int colorID = 9, string name = "")
        {

            // Request form allows us to extract data from the parameter in the http request.
            // So instead of passing the Player object as a parameter to the function,
            // we can extract the necessary data from the parameter.

            context.LudoGames.Find(long.Parse(gameID)).UpdatePlayer(playerID, colorID, name);
            context.SaveChanges();

        }

        [HttpDelete("{GameID}/players/{PlayerID}")]
        public void RemovePlayer(int colorID)
        {
            // Remove player where PlayerID matches player,
            // open for suggestions regarding logic behind it.

            //_game.RemovePlayer(color);
        }
        
    }
}
