using System;
using Microsoft.EntityFrameworkCore;

namespace birdwatcherAPI.Model
{
    public class BirdwatcherContext : DbContext
    {
        public BirdwatcherContext(DbContextOptions<BirdwatcherContext> options) : base(options)
        {
        }

        public DbSet<Vogel> Vogels { get; set; }

        public DbSet<Spotter> Spotters { get; set; }

        public DbSet<Waarneming> Waarnemingen { get; set; }

        //public DbSet<Familie> Families { get; set; }
    }
}
