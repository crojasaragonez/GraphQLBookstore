using GraphQLBookstore.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GraphQLBookstore.Repositories
{
    public class BookRepository
    {
        private readonly DataBaseContext _context;
        public BookRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ILookup<long, Book>> GetForAuthor(IEnumerable<long> authorIds)
        {
            var books = await _context.Books.Where(b => authorIds.Contains(b.AuthorId)).ToListAsync();
            return books.ToLookup(b => b.AuthorId);
        }
    }
}