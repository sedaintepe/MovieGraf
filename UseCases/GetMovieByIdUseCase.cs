using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataClassPluginInterfaces;

namespace UseCases
{
    public class GetMovieByIdUseCase : IGetMovieByIdUseCase
    {
        private readonly IMovieRepository _movieRepository;

        public GetMovieByIdUseCase(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Movie Execute(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

    }
}
