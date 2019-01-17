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
        // DELETE api/ludo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

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
            var game = new LudoGame(new Diece());
            game.AddPlayer("player1", PlayerColor.Blue);
            game.AddPlayer("player2", PlayerColor.Red);

            var players = game.GetPlayers();
            return players.Select(p => p.Name).ToArray();
        }

        // GET api/values
        [HttpGet("{a},{b}")]
        public int Get(int a, int b)
        {
            return Test.AddNumbers(a, b);
        }

        // GET DICK
        [HttpGet("DICKS/SIZE:{size}")]
        public string Get(int size)
        {
            return Test.Dick(size);
        }

        // POST api/ludo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/ludo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}