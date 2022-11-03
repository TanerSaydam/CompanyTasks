using Microsoft.EntityFrameworkCore;
using NewlatterWepApi.Models;

namespace NewlatterWepApi.Context
{
    public class NewsLatterDb : DbContext
    {
        public NewsLatterDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Newslatter> Newslatters { get; set; }
    }
}
