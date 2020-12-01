using GraphQL.Types;

namespace GraphQLBookstore.GraphQL.Types
{
    class MessageInputType : InputObjectGraphType
    {
        public MessageInputType()
        {
            Name = "MessageInput";
            Field<NonNullGraphType<StringGraphType>>("subject");
            Field<NonNullGraphType<StringGraphType>>("body");
        }
    }
}
