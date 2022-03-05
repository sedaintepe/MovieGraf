using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataClassPluginInterfaces;

namespace UseCases
{
    public class ViewMoviesByCategoryId : IViewMoviesByCategoryId
    {
        private readonly IMovieRepository _movieRepository;

        public ViewMoviesByCategoryId(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<Movie> Execute(int categoryId)
        {
            return _movieRepository.GetMovieByCategoryId(categoryId);
        }
    }
}
