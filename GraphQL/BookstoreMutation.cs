using GraphQL.Types;
using GraphQLBookstore.Repositories;
using GraphQLBookstore.GraphQL.Types;
using GraphQLBookstore.Models;

namespace GraphQLBookstore.GraphQL
{
    public class BookstoreMutation : ObjectGraphType
    {
        public BookstoreMutation(AuthorRepository authorRepository)
        {
            FieldAsync<AuthorType>(
                "createAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "input", Description = "Author object" }
                ),
                resolve: async context => {
                    var author = context.GetArgument<Author>("input");
                    return await context.TryAsyncResolve(
                        async c => await authorRepository.Add(author)
                    );
                }
            );

            FieldAsync<AuthorType>(
                "updateAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "id of the author to update" },
                    new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "input", Description = "Author object" }
                ),
                resolve: async context => {
                    var id = context.GetArgument<long>("id");
                    var author = context.GetArgument<Author>("input");
                    return await context.TryAsyncResolve(
                        async c => await authorRepository.Update(id, author)
                    );
                }
            );

            FieldAsync<AuthorType>(
                "deleteAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "id of the author to remove" }
                ),
                resolve: async context => {
                    var id = context.GetArgument<long>("id");
                    return await context.TryAsyncResolve(
                        async c => await authorRepository.Remove(id)
                    );
                }
            );
        }
    }
}
