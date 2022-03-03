using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewCategoriesUseCases
    {
        IEnumerable<Category> Execute();
    }
}