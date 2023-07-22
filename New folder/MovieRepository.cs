using WebApiProject.Models;

namespace WebApiProject.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private List<Movie> _movies;

        public MovieRepository()
        {
            _movies = new List<Movie>();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _movies;
        }

        public Movie GetMovieById(int id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        public void AddMovie(Movie movie)
        {
            _movies.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            var existingMovie = _movies.FirstOrDefault(m => m.Id == movie.Id);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.Genre = movie.Genre;
                existingMovie.ReleaseDate = movie.ReleaseDate;
            }
        }

        public void DeleteMovie(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                _movies.Remove(movie);
            }
        }
    }
}
