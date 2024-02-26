using Microsoft.EntityFrameworkCore;
using Webapi.Nc7.Movies.Models;

namespace Webapi.Nc7.Movies.Data
{
    public class ApplicationDbContex : DbContext
    {
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options) : base(options)
        {
            
        }

        //Add models here
        public DbSet<Category> Category { get; set; }
        public DbSet<Movie> Movie { get; set; }

    }
}
