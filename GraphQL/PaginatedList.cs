using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;

namespace GraphQLBookstore.GraphQL
{
    class PaginatedList<T>
    {
        public static List<T> Paginate(IQueryable<T> result, ResolveFieldContext<object> context)
        {
            int page = context.GetArgument<int>("page");
            int pageSize = context.GetArgument<int>("pageSize");
            return result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
