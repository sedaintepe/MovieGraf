using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataClassPluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Graf db;

        public CategoryRepository(Graf db)
        {
            this.db = db;
        }
        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = db.Categories.Find(categoryId);
            if (category == null) return;

            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public Category GetCategoryById(int categoryId)
        {
            return db.Categories.Find(categoryId);
        }

        public IEnumerable<Category> GetRepositories()
        {
            return db.Categories.ToList();
        }

        public void UpdateCategory(Category category)
        {
            var cat = db.Categories.Find(category.Id);
            cat.Name = category.Name;
            cat.Description = category.Description;
            db.SaveChanges();
        }
    }
}
