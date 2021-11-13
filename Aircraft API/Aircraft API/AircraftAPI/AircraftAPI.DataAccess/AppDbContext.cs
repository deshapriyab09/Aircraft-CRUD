using ArcraftAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftAPI.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Aircraft> Aircrafts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = "Server=DESKTOP-6VSET39; Database=StudentsDb; User Id=sa; Password=tommya";
            //optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>().HasData(new Aircraft[]
            {
                new Aircraft {Id = 1, Make = "Boeing",Model="777-300ER",Registration="G-RNAC”",Location="London Gatwick",DateTime=DateTime.Now},
                new Aircraft {Id = 2, Make = "Boeing1",Model="777-300ER1",Registration="G-RNAC1",Location="London Gatwick1",DateTime=DateTime.Now},
            });
        }
    }
}
