using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Models;

namespace TechnoStore.Services.Interfaces
{
    public interface IHomeService
    {

        IEnumerable<Category> GetAllCategories { get; }

        Task<Category> CreateCategory(string name, string imagePath);

        Task<Category> EditCategory(int id, string name, string imagePath);

        Category GetCategory(int id);
    }
}
