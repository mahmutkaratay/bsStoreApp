using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore.Extensions
{
    public static class BookRepositoryExtensions
    {
        public static IQueryable<Book> FilterBooks(this IQueryable<Book> books, uint minPrice, uint maxPrcice) =>
            books.Where(book =>
            book.Price >= minPrice &&
            book.Price <= maxPrcice);

        public static IQueryable<Book> Search(this IQueryable<Book> books, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))

            {
                return books;
            }

            var lowerCaseTerm = searchTerm.Trim().ToLower();


            return books.Where(book => book.Title.ToLower().Contains(lowerCaseTerm));

        }


    }
}
