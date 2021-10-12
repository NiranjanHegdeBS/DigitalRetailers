using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalRetailers.Models;

namespace DigitalRetailers.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; } 

        public DbSet<Laptop> Laptops { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=H5CG1220SMG;Database=DigitalRetailersDB;Integrated Security=true");
        }
        
    }
}
