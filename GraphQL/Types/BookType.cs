using GraphQL.Types;
using GraphQLBookstore.Models;

namespace GraphQLBookstore.GraphQL.Types
{
    class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Name = "Book";
            Field(x => x.Id).Description("The ID of the Book.");
            Field(x => x.Name).Description("The name of the Book");
            Field(x => x.Description).Description("The description of the Book");
            Field(x => x.Price).Description("The price of the Book");
            //Field(x => x.AuthorId).Description("The AuthorId of the Book");
        }
    }
}