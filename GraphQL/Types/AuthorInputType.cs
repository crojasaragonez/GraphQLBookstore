using GraphQL.Types;

namespace GraphQLBookstore.GraphQL.Types
{
    class AuthorInputType : InputObjectGraphType
    {
        public AuthorInputType()
        {
            Name = "AuthorInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}