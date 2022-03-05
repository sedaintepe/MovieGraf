using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataClassPluginInterfaces;


namespace UseCases
{
    public class AddMovieUseCase:IAddMovieUseCase
    {
        private readonly IMovieRepository _movieRepository;
        public AddMovieUseCase(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public void Execute(Movie movie)
        {
            _movieRepository.AddMovie(movie);
        }
    }
}
