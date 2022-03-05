using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataClassPluginInterfaces;

namespace UseCases
{
    public class DeleteMovieUseCase : IDeleteMovieUseCase
    {
        private readonly IMovieRepository _movie;
        public DeleteMovieUseCase(IMovieRepository movie)
        {
            _movie = movie;
        }
        public void Delete(int id)
        {
            _movie.DeleteMovie(id);
        }
    }
}
