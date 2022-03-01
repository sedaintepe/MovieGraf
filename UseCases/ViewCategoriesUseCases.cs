using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataClassPluginInterfaces;

namespace UseCases
{
    public class ViewCategoriesUseCases
    {
        private readonly ICategoryRepository CategoryRepository;
        public ViewCategoriesUseCases(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public IEnumerable<Category> Execute()
        {
           return CategoryRepository.GetRepositories();
        }
    }
}
