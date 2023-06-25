using API.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Entity.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Conta> Conta { get; set; }
    }
}
