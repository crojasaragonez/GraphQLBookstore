using GraphQL.Types;
using GraphQLBookstore.Models;
using GraphQLBookstore.Repositories;

namespace GraphQLBookstore.GraphQL.Types
{
    class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType(BookRepository bookRepository)
        {
            Name = "Author";
            Field(x => x.Id).Description("The ID of the Author.");
            Field(x => x.Name).Description("The name of the Author");
            Field<ListGraphType<BookType>>(
                "books",
                resolve: context => {
                    return bookRepository.GetForAuthor(context.Source.Id);
                }
            );
        }
    }
}