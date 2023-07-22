
    using Microsoft.AspNetCore.Mvc;
    using WebApiProject.Models;
    using WebApiProject.Repositories;
    using WebApiProject.Models;
    using WebApiProject.Repositories;

    namespace WebApiProject.Controllers
    {
        [Route("api/movies")]
        [ApiController]
        public class MoviesController : ControllerBase
        {
            private readonly IMovieRepository _movieRepository;

            public MoviesController(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            [HttpGet]
            public IActionResult GetAllMovies()
            {
                var movies = _movieRepository.GetAllMovies();
                return Ok(movies);
            }

            [HttpGet("{id}")]
            public IActionResult GetMovieById(int id)
            {
                var movie = _movieRepository.GetMovieById(id);
                if (movie == null)
                {
                    return NotFound();
                }
                return Ok(movie);
            }
        
            public IActionResult AddMovie([FromBody] Movie movie)
            {
                _movieRepository.AddMovie(movie);
                return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
            }

            [HttpPut("{id}")]
            public IActionResult UpdateMovie(int id, [FromBody] Movie movie)
            {
                var existingMovie = _movieRepository.GetMovieById(id);
                if (existingMovie == null)
                {
                    return NotFound();
                }
                existingMovie.Title = movie.Title;
                existingMovie.Genre = movie.Genre;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                _movieRepository.UpdateMovie(existingMovie);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteMovie(int id)
            {
                var movie = _movieRepository.GetMovieById(id);
                if (movie == null)
                {
                    return NotFound();
                }

                _movieRepository.DeleteMovie(id);

                return NoContent();
            }
        }
    }

