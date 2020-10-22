using GraphQL.Types;
using GraphQLBookstore.Repositories;
using GraphQLBookstore.GraphQL.Types;

namespace GraphQLBookstore.GraphQL
{
    public class BookstoreQuery : ObjectGraphType
    {
        public BookstoreQuery(AuthorRepository authorRepository)
        {
            Field<ListGraphType<AuthorType>>(
                "authors",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "name", Description = "The name of the author" }
                ),
                resolve: context => authorRepository.All(context)
            );
        }
    }
}