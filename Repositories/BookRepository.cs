using GraphQLBookstore.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using GraphQL.Types;

namespace GraphQLBookstore.Repositories
{
    public class BookRepository
    {
        private readonly DataBaseContext _context;
        public BookRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> All(ResolveFieldContext<object> context)
        {
            var result = from b in _context.Books select b;
            if(context.HasArgument("name")){
                var value = context.GetArgument<string>("name");
                result = result.Where(a => a.Name.Contains(value));
            }
            if(context.HasArgument("description")){
                var value = context.GetArgument<string>("description");
                result = result.Where(a => a.Description.Contains(value));
            }
            if(context.HasArgument("price")){
                var value = context.GetArgument<double>("price");
                result = result.Where(a => a.Price == value);
            }
            if(context.HasArgument("authorId")){
                var value = context.GetArgument<long>("authorId");
                result = result.Where(a => a.AuthorId == value);
            }
            return result;
        }


        public Book Find(long id) {
            return _context.Books.Find(id);
        }

        public async Task<ILookup<long, Book>> GetForAuthor(IEnumerable<long> authorIds)
        {
            var books = await _context.Books.Where(b => authorIds.Contains(b.AuthorId)).ToListAsync();
            return books.ToLookup(b => b.AuthorId);
        }
    }
}