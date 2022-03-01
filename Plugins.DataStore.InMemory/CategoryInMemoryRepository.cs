using CoreBusiness;
using System;
using System.Collections.Generic;
using UseCases.DataClassPluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> _categories;
        public CategoryInMemoryRepository()
        {
            _categories = new List<Category>()
            {
                new Category{Id=1,Name="Action",Description="Action" },
                new Category{Id=2,Name="Adventure",Description="Adventure" },
                new Category{Id=3,Name="Comedy",Description="Comedy" },
                new Category{Id=4,Name="Drama",Description="Drama" },
                new Category{Id=5,Name="Crime",Description="Crime" }
            };
        }
        public IEnumerable<Category> GetRepositories()
        {
            return _categories;  
        }
    }
}
