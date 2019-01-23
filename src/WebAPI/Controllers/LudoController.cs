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

        // POST: api/ludo
        [HttpPost]
        public LudoGame[] AddNewGame()
        {
            context.LudoGames.Add(new LudoGame(new Dice()));
            context.SaveChanges();

            return context.LudoGames.ToArray();
        }
    }
}
