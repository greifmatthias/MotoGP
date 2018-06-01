using L01.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L01.Data
{
    public class GPContext : DbContext
    {
        public GPContext(DbContextOptions<GPContext> options) : base(options)
        {

        }

        public DbSet<Race> Races { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Rider> Riders { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Race>().ToTable("Race");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Rider>().ToTable("Rider");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
        }
    }
}
