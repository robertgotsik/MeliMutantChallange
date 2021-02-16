using MeliMutantChallange.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeliMutantChallange
{
    public class MutantContext : DbContext
    {
        public MutantContext(DbContextOptions<MutantContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<MeliMutantChallange.Models.Adn> Adn { get; set; }
    }
}
