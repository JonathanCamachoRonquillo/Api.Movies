using Webapi.Nc7.Movies.Models;

namespace Webapi.Nc7.Movies.Repository.IRepository
{
    public interface IRepositoryMovie
    {
        ICollection<Movie> GetMovies();
        Movie GetMovieById(int movieId);
        bool CreateMovie(Movie movieC);
        bool UpdateMovie(Movie movieU);
        bool DeleteMovie(Movie movieD);
        bool ExistMovie(string movieName);
        bool ExistMovie(int movieId);
        bool Save();
    }
}
