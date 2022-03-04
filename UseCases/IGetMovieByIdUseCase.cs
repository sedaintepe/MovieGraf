using CoreBusiness;

namespace UseCases
{
    public interface IGetMovieByIdUseCase
    {
        Movie Execute(int id);
    }
}