using GraphQL.Types;

namespace GraphQLBookstore.GraphQL.Types
{
    class AuthorInputType : InputObjectGraphType
    {
        public AuthorInputType()
        {
            Name = "AuthorInput";
            Field<IdGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}