using Webapi.Nc7.Movies.Models;
using Webapi.Nc7.Movies.Repository.IRepository;

namespace Webapi.Nc7.Movies.Repository
{
    public class RepositoryMovie : IRepositoryMovie
    {
        public bool CreateMovie(Movie movieC)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMovie(Movie movieD)
        {
            throw new NotImplementedException();
        }

        public bool ExistMovie(string movieName)
        {
            throw new NotImplementedException();
        }

        public bool ExistMovie(int movieId)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int movieId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Movie> GetMovies()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateMovie(Movie movieU)
        {
            throw new NotImplementedException();
        }
    }
}
