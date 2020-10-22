using GraphQLBookstore.Models;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Book> GetForAuthor(long id)
        {
            return _context.Books.Where(b => b.AuthorId == id);
        }
    }
}