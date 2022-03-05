using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewMoviesByCategoryId
    {
        IEnumerable<Movie> Execute(int categoryId);
    }
}