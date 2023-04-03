using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task CreateOneBookAsync(Category category)
        {
            _manager.Category.CreateOneCategory(category);
            await _manager.SaveAsync();
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity = await GetOneCategoryByIdAsync(id, trackChanges);

            _manager.Category.DeleteOneCategory(entity);
            await _manager.SaveAsync();
        }
        public async Task UpdateOneBookAsync(int id, Category category, bool trackChanges)
        {
            var entity = await GetOneCategoryByIdAsync(id, trackChanges);

            if (category is null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            _manager.Category.Update(entity);
            await _manager.SaveAsync();

        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await _manager.Category.GetAllCategoriesAsync(trackChanges);
        }

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            var category = await _manager.Category.GetOneCategoryByIdAsync(id, trackChanges);
            if (category is null)

            {
                throw new CategoryNotFoundException(id);
            }
            return category;
        }


    }
}
