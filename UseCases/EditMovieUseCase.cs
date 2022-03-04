using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataClassPluginInterfaces;

namespace UseCases
{
    public class EditMovieUseCase : IEditMovieUseCase
    {
        private readonly IMovieRepository _movieRepository;
        public EditMovieUseCase(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public void Execute(Movie movie)
        {
            _movieRepository.UpdateMovie(movie);
        }
    }
}
