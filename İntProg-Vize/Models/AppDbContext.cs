using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using İntProg_Vize.Models;

namespace IntProg_Vize.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<NewsType> NewsTypes { get; set; } /* DİKKAT +s */
        public DbSet<News> Haberler {  get; set; }
        public object News { get; internal set; }
    }
}
