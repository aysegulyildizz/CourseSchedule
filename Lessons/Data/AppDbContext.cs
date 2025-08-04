using Microsoft.EntityFrameworkCore;
using DersProgramiMvc.Models;

namespace DersProgramiMvc.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Ders> Dersler { get; set; }
    }
}