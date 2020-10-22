using GraphQL.Types;
using GraphQLBookstore.Models;
using GraphQLBookstore.Repositories;

namespace GraphQLBookstore.GraphQL.Types
{
    class BookType : ObjectGraphType<Book>
    {
        public BookType(AuthorRepository authorRepository)
        {
            Name = "Book";
            Field(x => x.Id).Description("The ID of the Book.");
            Field(x => x.Name).Description("The name of the Book");
            Field(x => x.Description).Description("The description of the Book");
            Field(x => x.Price).Description("The price of the Book");
            Field(x => x.AuthorId).Description("The AuthorId of the Book");
            Field<AuthorType>(
                "author",
                resolve: context => {
                    return authorRepository.Find(context.Source.Id);
                }
            );
        }
    }
}