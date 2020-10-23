using GraphQL.Types;
using GraphQLBookstore.Repositories;
using GraphQLBookstore.GraphQL.Types;

namespace GraphQLBookstore.GraphQL
{
    public class BookstoreQuery : ObjectGraphType
    {
        public BookstoreQuery(AuthorRepository authorRepository, BookRepository bookRepository)
        {
            Field<ListGraphType<AuthorType>>("authors",
                                             arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "name" }),
                                             resolve: context => authorRepository.All(context));

            Field<AuthorType>("author",
                              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                              resolve: context => authorRepository.Find(context.GetArgument<long>("id")));

            Field<ListGraphType<BookType>>("books",
                                           arguments: new QueryArguments(
                                               new QueryArgument<StringGraphType> { Name = "name" },
                                               new QueryArgument<StringGraphType> { Name = "description" },
                                               new QueryArgument<FloatGraphType> { Name = "price" },
                                               new QueryArgument<IntGraphType> { Name = "authorId" }
                                           ),
                                           resolve: context => bookRepository.All(context));

            Field<BookType>("book",
                            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                            resolve: context => bookRepository.Find(context.GetArgument<long>("id")));
        }
    }
}
