using Microsoft.EntityFrameworkCore;
using RehberWebApi.Models.Entities;

namespace RehberWebApi.Models.Context
{
    public class RehberDbContext : DbContext
    {
        public RehberDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Rehber> Rehbers { get; set; }
        public DbSet<IletisimBilgileri> IletisimBilgileris { get; set; }
    }
}
