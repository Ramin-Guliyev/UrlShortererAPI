using Microsoft.EntityFrameworkCore;
using UrlShortererAPI.Models;

namespace UrlShortererAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Url> UrlModels { get; set; }
    }
}
