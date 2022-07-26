using Microsoft.EntityFrameworkCore;
using SeriesListWeb.Models;

namespace SeriesListWeb.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Series> Serie { get; set; }
    }
}
