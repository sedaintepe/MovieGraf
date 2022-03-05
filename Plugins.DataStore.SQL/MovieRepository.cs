using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataClassPluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class MovieRepository : IMovieRepository
    {
        private readonly Graf db;

        public MovieRepository(Graf db)
        {
            this.db = db;
        }
        public void AddMovie(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie == null) return;
            db.Movies.Remove(movie);
            db.SaveChanges();
        }

        public IEnumerable<Movie> GetMovieByCategoryId(int categoryId)
        {
            return db.Movies.Where(x => x.CategoryId == categoryId).ToList();
        }

        public Movie GetMovieById(int movieId)
        {
            return db.Movies.Find(movieId);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return db.Movies.ToList();
        }

        public void UpdateMovie(Movie movie)
        {
            var move = db.Movies.Find(movie.Id);
            move.MovieName = movie.MovieName;
            move.ReleaseYear = movie.ReleaseYear;
            move.MovieImdb = movie.MovieImdb;
            move.DirectorName = movie.DirectorName;
            move.CategoryId = movie.CategoryId;
            db.SaveChanges();
        }
    }
}
