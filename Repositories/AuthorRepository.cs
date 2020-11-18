using GraphQLBookstore.Models;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using System.Threading.Tasks;
using GraphQLBookstore.GraphQL;

namespace GraphQLBookstore.Repositories
{
    public class AuthorRepository
    {
        private readonly DataBaseContext _context;
        public AuthorRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> All(ResolveFieldContext<object> context)
        {
            var result = from a in _context.Authors select a;
            if(context.HasArgument("name")){
                var value = context.GetArgument<string>("name");
                result = result.Where(a => a.Name.Contains(value));
            }
            return PaginatedList<Author>.Paginate(result, context);
        }

        public Author Find(long id) {
            return _context.Authors.Find(id);
        }

        public async Task<Author> Add(Author author) {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> Update(long id, Author author) {
            author.Id = id;
            var updated = (_context.Authors.Update(author)).Entity;
            if (updated == null)
            {
                return null;
            }
            await _context.SaveChangesAsync();
            return updated;
        }

        public async Task<Author> Remove(long id) {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return null;
            }
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return author;
        }
    }
}
