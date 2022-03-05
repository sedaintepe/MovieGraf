using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataClassPluginInterfaces;

namespace UseCases
{
    public class ViewMovieUseCase : IViewMovieUseCase
    {
        private readonly IMovieRepository _movieRepository;
        public ViewMovieUseCase(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IEnumerable<Movie> Execute()
        {
            return _movieRepository.GetMovies();
        }
    }
}
