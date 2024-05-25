using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for Difficulties
            //Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty
                {
                    Id = Guid.Parse("7b295176-d036-4a7a-8ea1-a32dec38b634"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("01798283-a255-4025-9090-1d78072db87e"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("d2e913e0-b45b-4595-b028-932d81e5629b"),
                    Name = "Hard"
                }
            };

            //Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);
        }
    }
}