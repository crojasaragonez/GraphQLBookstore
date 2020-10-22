using GraphQL.Types;
using GraphQLBookstore.Models;
using GraphQLBookstore.Repositories;
using GraphQL.DataLoader;

namespace GraphQLBookstore.GraphQL.Types
{
    class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Name = "Author";
            Field(x => x.Id).Description("The ID of the Author.");
            Field(x => x.Name).Description("The name of the Author");
        }
    }
}