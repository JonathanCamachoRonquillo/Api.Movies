using Microsoft.EntityFrameworkCore;
using Webapi.Nc7.Movies.Data;
using Webapi.Nc7.Movies.Models;
using Webapi.Nc7.Movies.Repository.IRepository;

namespace Webapi.Nc7.Movies.Repository
{
    public class RepositoryMovie : IRepositoryMovie
    {
        private readonly ApplicationDbContex _dbContex;
        public RepositoryMovie(ApplicationDbContex dbContext)
        {
            _dbContex = dbContext;
        }

        public bool CreateMovie(Movie movie)
        {
            movie.CreationDate = DateTime.Now;
            _dbContex.Add(movie);
            return Save();
        }

        public bool DeleteMovie(Movie movie)
        {
            _dbContex.Remove(movie);
            return Save();
        }

        public bool ExistsMovie(string movieName)
        {
            bool exists = _dbContex.Movie.Any(x => x.Name.ToLower().Trim() == movieName.ToLower().Trim());
            return exists;
        }

        public bool ExistsMovie(int movieId)
        {
            return _dbContex.Movie.Any(x => x.Id == x.categoryId);
        }

        public Movie GetMovieById(int movieId)
        {
            return _dbContex.Movie.FirstOrDefault(x => x.Id == movieId);
        }

        public ICollection<Movie> GetMovies()
        {
            return _dbContex.Movie.OrderBy(x => x.Name).ToList();
        }

        public ICollection<Movie> GetMoviesByCategory(int catId)
        {
            return _dbContex.Movie.Include(x => x.Category).Where(x => x.categoryId == catId).ToList();
        }

        public ICollection<Movie> GetMoviesByName(string movieName)
        {
            IQueryable<Movie> query = _dbContex.Movie;

            if (!string.IsNullOrEmpty(movieName))
            {
                query = query.Where(x => x.Name.Contains(movieName) || x.Description.Contains(movieName));
            }

            return query.ToList();

        }

        public bool Save()
        {
            return _dbContex.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateMovie(Movie movie)
        {
            movie.CreationDate = DateTime.Now;
            _dbContex.Update(movie);
            return Save();
        }
    }
}
