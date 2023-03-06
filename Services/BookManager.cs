using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BookDto> CreateOneBookAsync(BookDtoForInsertion bookDtoForInsertion)
        {
            var book = _mapper.Map<Book>(bookDtoForInsertion);
            _manager.Book.CreateOneBook(book);
            await _manager.SaveAsync();
            return _mapper.Map<BookDto>(book);
        }


        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity =await GetOneBookByIdAndCheckExists(id, trackChanges);
         
            _manager.Book.DeleteOneBook(entity);
            await _manager.SaveAsync();
        }

        

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges)
        {
            var books = await _manager.Book.GetAllBooksAsync(trackChanges);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

       
        public async Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges)
        {
            var book= await GetOneBookByIdAndCheckExists(id, trackChanges);

            return _mapper.Map<BookDto>(book);
        }

       

        public async Task<(BookDtoForUpdate bookDtoForUpdate, Book book)> GetOneBookForPatchAsync(int id, bool trackChanges)
        {
            var book= await GetOneBookByIdAndCheckExists(id, trackChanges);


            var bookDtoForUpdate = _mapper.Map<BookDtoForUpdate>(book);
            return (bookDtoForUpdate, book);
        }

      
        public async Task SaveChangesForPatchAsync(BookDtoForUpdate bookDtoForUpdate, Book book)
        {
            _mapper.Map<BookDtoForUpdate>(book);
            await _manager.SaveAsync();
        }

        
        public async Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            var entity = await GetOneBookByIdAndCheckExists(id, trackChanges);

            if (bookDto is null)
            {
                throw new ArgumentNullException(nameof(bookDto));
            }

            entity = _mapper.Map<Book>(bookDto);

            _manager.Book.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Book> GetOneBookByIdAndCheckExists(int id, bool trackChanges)
        {
            var book = await _manager.Book.GetOneBookByIdAsync(id, trackChanges);

            if (book is null)
            {
                throw new BookNotFoundException(id);
            }
            return book;
        }
    }
}
