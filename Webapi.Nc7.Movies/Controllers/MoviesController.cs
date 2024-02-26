using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Webapi.Nc7.Movies.Models;
using Webapi.Nc7.Movies.Models.Dtos;
using Webapi.Nc7.Movies.Repository.IRepository;

namespace Webapi.Nc7.Movies.Controllers
{
    [Route("api/peliculas")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IRepositoryMovie _repMovie;
        private readonly IMapper _mapper;
        public MoviesController(IMapper mapper, IRepositoryMovie repMovie)
        {
            _mapper = mapper;
            _repMovie = repMovie;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetMoviesController() {

            var lstMovies = _repMovie.GetMovies();
            var lstMoviesDto = new List<MovieDto>();

            foreach (var movie in lstMovies)
            {
                lstMoviesDto.Add(_mapper.Map<MovieDto>(movie));
            }

            return Ok(lstMoviesDto);

        }

        [HttpGet("{movieId:int}", Name = "GetMovieController")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMovieController(int movieId)
        {
            var movie = _repMovie.GetMovieById(movieId);

            if (movie == null)
            {
                return NotFound();
            }

            var movieDto = _mapper.Map<MovieDto>(movie);

            return Ok(movieDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(MovieDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateMovieCtr([FromBody] MovieDto movieDto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            if (_repMovie.ExistsMovie(movieDto.Name)) 
            {
                ModelState.AddModelError("",$"La pelicula {movieDto.Name} ya existe en el sistema");
                return BadRequest(ModelState);
            }

            var movie = _mapper.Map<Movie>(movieDto);

            if (!_repMovie.CreateMovie(movie))
            {
                ModelState.AddModelError("",$"Ocurrio un problema al registrar la pelicula {movieDto.Name}");
                return StatusCode(500,ModelState);
            }

            return CreatedAtRoute("GetMovieController", new { movieId = movie.Id }, movie);

        }
    }
}
