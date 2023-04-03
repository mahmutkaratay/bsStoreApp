using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
        Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges);
        Task CreateOneBookAsync(Category category);
        Task UpdateOneBookAsync(int id, Category category, bool trackChanges);
        Task DeleteOneBookAsync(int id, bool trackChanges);

    }
}
