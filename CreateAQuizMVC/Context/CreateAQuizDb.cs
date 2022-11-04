using CreateAQuizMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CreateAQuizMVC.Context
{
    public class CreateAQuizDb : IdentityDbContext<AppUser>
    {
        public CreateAQuizDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<New> News { get; set; }
    }
}
