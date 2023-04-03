using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly  IBookRepository  _bookRepository;
        private readonly  ICategoryRepository  _categoryRepository;

        public RepositoryManager(ICategoryRepository categoryRepository, IBookRepository bookRepository, RepositoryContext context)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            _context = context;
        }

        public IBookRepository Book => _bookRepository;

        public ICategoryRepository Category => _categoryRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
