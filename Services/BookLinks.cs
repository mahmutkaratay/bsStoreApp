using Entities.DataTransferObjects;
using Entities.LinkModels;
using Entities.LogModel;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookLinks : IBookLinks
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IDataShaper<BookDto> _dataShaper;

        public BookLinks(LinkGenerator linkGenerator, IDataShaper<BookDto> dataShaper)
        {
            _linkGenerator = linkGenerator;
            _dataShaper = dataShaper;
        }

        public LinkResponse TryGenerateLinks(IEnumerable<BookDto> booksDto, string fields, HttpContext context)
        {
            var shapedBooks = ShapeData(booksDto, fields);
            if (ShouldGenerateLinks(context))
                return ReturnLinkedBooks(booksDto, fields, context, shapedBooks);

            return ReturnShapedBooks(shapedBooks);
        }

        private LinkResponse ReturnLinkedBooks(IEnumerable<BookDto> booksDto, string fields, HttpContext context, List<Entity> shapedBooks)
        {
            var bookDtoList = booksDto.ToList();
            for (int index = 0; index < bookDtoList.Count; index++)
            {
                var bookLinks = CreateForBook(context, bookDtoList[index], fields);
                shapedBooks[index].Add("Links", bookLinks);
            }

            var bookCollection = new LinkCollectionWrapper<Entity>(shapedBooks);
            CreateForBooks(context, bookCollection);
            return new LinkResponse { HasLinks = true, LinkedEntities = bookCollection };
        }
        private LinkCollectionWrapper<Entity> CreateForBooks(HttpContext context,
            LinkCollectionWrapper<Entity> bookCollectionWrapper)
        {
            bookCollectionWrapper.Links.Add(new Link()
            {
                Href = $"/api/{context.GetRouteData().Values["controller"].ToString().ToLower()}",
                Rel = "self",
                Method = "GET"
            });
            return bookCollectionWrapper;

        }
        private List<Link> CreateForBook(HttpContext context, BookDto bookDto, string fields)
        {
            var links = new List<Link>()
            {
                new Link()
                {
                    Href= $"/api/{context.GetRouteData().Values["controller"].ToString().ToLower()}"+
                    $"/{bookDto.Id}",
                    Rel= "self",
                    Method = "GET"
                },
                new Link()
                {
                    Href= $"/api/{context.GetRouteData().Values["controller"].ToString().ToLower()}",
                    Rel= "create",
                    Method = "POST"
                },
            };
            return links;
        }

        private LinkResponse ReturnShapedBooks(List<Entity> shapedBooks)
        {
            return new LinkResponse() { ShapedEntities = shapedBooks };
        }

        private bool ShouldGenerateLinks(HttpContext context)
        {
            var mediaType = (MediaTypeHeaderValue)context.Items["AcceptHeaderMediaType"];
            return mediaType.SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
        }

        private List<Entity> ShapeData(IEnumerable<BookDto> booksDto, string fields)
        {
            return _dataShaper.ShapeData(booksDto, fields)
                .Select(b => b.Entity)
                .ToList();

        }
    }
}
