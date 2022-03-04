using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewMovieUseCase
    {
       IEnumerable<Movie> Execute();
    }
}