using GraphQLBookstore.Models;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;

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
            return result;
        }
    }
}