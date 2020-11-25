using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnoStore.Data;
using TechnoStore.Models;
using TechnoStore.Services.Interfaces;

namespace TechnoStore.Services
{
    public class HomeService : IHomeService
    {
        private readonly TechnoStoreDbContext _dbContext;

        public HomeService(TechnoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetAllCategories
        {
            get
            {
                _dbContext.Products.Load();
                return _dbContext.Categories.ToList();
            }
        }

        public Category GetCategory(int id)
        {
            return _dbContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public async Task<Category>  CreateCategory(string name, string imagePath)
        {
            var category = new Category()
            {
                Name = name,
                Slug = name.ToLower().Replace(' ', '-'),
                CategoryPicUrl = imagePath
            };

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category> EditCategory(int id, string name, string imagePath)
        {
            var category = GetCategory(id);
            category.Name = name;
            category.Slug = name.ToLower().Replace(' ', '-');
            category.CategoryPicUrl = imagePath;

            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();

            return category;
        }

    }
}
