using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataClassPluginInterfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovies();
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        Movie GetMovieById(int movieId);
        void DeleteMovie(int id);
    }
}
