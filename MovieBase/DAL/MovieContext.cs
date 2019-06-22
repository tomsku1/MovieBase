using MovieBase.Models;
using System.Data.Entity;

namespace MovieBase.DAL
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}