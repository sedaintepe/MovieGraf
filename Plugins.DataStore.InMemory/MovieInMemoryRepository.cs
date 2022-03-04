using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataClassPluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class MovieInMemoryRepository : IMovieRepository
    {
        private List<Movie> _movies;
        public MovieInMemoryRepository()
        {
            _movies = new List<Movie>()
            {
                new Movie{Id=1, CategoryId=1,DirectorName="John Samuel",MovieName="Evil Camp",MovieImdb="3.2",ReleaseYear="2000" },
                new Movie{Id=1, CategoryId=2,DirectorName="John Simul",MovieName="İmage Camp",MovieImdb="7.2",ReleaseYear="1980" },
                new Movie{Id=1, CategoryId=3,DirectorName="John Luel",MovieName="Devil Camp",MovieImdb="2.2",ReleaseYear="2003" }
            };
        }

        public void AddMovie(Movie movie)
        {
            if (_movies.Any(x => x.MovieName.Equals(movie.MovieName, StringComparison.OrdinalIgnoreCase))) return;
            if (_movies != null && _movies.Count > 0)
            {
                var maxId = _movies.Max(x => x.Id);
                movie.Id = maxId + 1;
            }
            else
            {
                movie.Id = 1;
            }
            _movies.Add(movie);
        }

        IEnumerable<Movie> IMovieRepository.GetMovies()
        {
           return _movies;
        }
        public void UpdateMovie(Movie movie)
        {
            var moveToUpdate = GetMovieById(movie.Id);
            if (moveToUpdate != null)
            {
                moveToUpdate.MovieName = movie.MovieName;
                moveToUpdate.CategoryId = movie.CategoryId;
                moveToUpdate.ReleaseYear = movie.ReleaseYear;
                moveToUpdate.DirectorName = movie.DirectorName;
                moveToUpdate.MovieImdb = movie.MovieImdb;
            }
        }
        public Movie GetMovieById(int movieId)
        {
            return _movies?.FirstOrDefault(x => x.Id == movieId);
        }
        public void DeleteMovie(int movieId)
        {
            var moveToDelete = GetMovieById(movieId);
            if (moveToDelete != null) _movies.Remove(moveToDelete);
        }
    }
}
