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
        bool ExistsMovie(string movieName);
        bool ExistsMovie(int movieId);

        //New methods to search for movies by category and search by name
        ICollection<Movie> GetMoviesByCategory(int categoryId);
        ICollection<Movie> GetMoviesByName(string movieName);

        bool Save();
    }
}
