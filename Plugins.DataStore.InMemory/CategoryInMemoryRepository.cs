using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddCategory(Category category)
        {
            if (_categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (_categories != null && _categories.Count > 0)
            {
                var maxId = _categories.Max(x => x.Id);
                category.Id = maxId + 1;
            }
            else
            {
                category.Id = 1;
            }
            _categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            var catToUpdate = GetCategoryById(category.Id);
            if (catToUpdate != null)
            {
                catToUpdate.Name = category.Name;
                catToUpdate.Description = category.Description;
            }
        }

        public IEnumerable<Category> GetRepositories()
        {
            return _categories;  
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categories?.FirstOrDefault(x => x.Id == categoryId);
        }
        public void DeleteCategory(int categoryId)
        {
             _categories?.Remove(GetCategoryById(categoryId));
        }
    }
}
