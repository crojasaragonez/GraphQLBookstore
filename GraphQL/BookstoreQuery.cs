using GraphQL.Types;
using GraphQLBookstore.Repositories;
using GraphQLBookstore.GraphQL.Types;

namespace GraphQLBookstore.GraphQL
{
    public class BookstoreQuery : ObjectGraphType
    {
        public BookstoreQuery(AuthorRepository authorRepository, BookRepository bookRepository)
        {
            Field<ListGraphType<AuthorType>>(
                "authors",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "name", Description = "The name of the author" }
                ),
                resolve: context => authorRepository.All(context)
            );

            Field<AuthorType>(
                "author",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "The id of the author" }),
                resolve: context => {
                    return authorRepository.Find(context.GetArgument<long>("id"));
                }
            );

            Field<ListGraphType<BookType>>(
                "books",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "name", Description = "The name of the book" },
                    new QueryArgument<StringGraphType> { Name = "description", Description = "The description of the book" },
                    new QueryArgument<FloatGraphType> { Name = "price", Description = "The price of the book" },
                    new QueryArgument<IntGraphType> { Name = "authorId", Description = "The AuthorId of the book" }
                ),
                resolve: context => bookRepository.All(context)
            );

            Field<BookType>(
                "book",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "The id of the book" }),
                resolve: context => {
                    return bookRepository.Find(context.GetArgument<long>("id"));
                }
            );
        }
    }
}
