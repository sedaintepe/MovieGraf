using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataClassPluginInterfaces;

namespace UseCases
{

    public class DeleteCategoryUseCase : IDeleteCategoryUseCase
    {
        private readonly ICategoryRepository _category;
        public DeleteCategoryUseCase(ICategoryRepository category)
        {
            _category = category;
        }
        public void Delete(int id)
        {
            _category.DeleteCategory(id);
        }




    }
}
