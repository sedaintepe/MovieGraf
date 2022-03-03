using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataClassPluginInterfaces;

namespace UseCases
{
    public class EditCategoryUseCase : IEditCategoryUseCase
    {
        private readonly ICategoryRepository _category;
        public EditCategoryUseCase(ICategoryRepository category)
        {
            _category = category;
        }

        public void Execute(Category category)
        {
            _category.UpdateCategory(category);
        }
    }
}
