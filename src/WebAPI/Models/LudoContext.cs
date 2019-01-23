using LudoGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
namespace WebAPI.Models
{
    public class LudoContext : DbContext
    {
        public LudoContext(DbContextOptions<LudoContext> options)
            :base(options)
        {
        }

        public DbSet<LudoGame> LudoGames { get; set; }
    }
}
