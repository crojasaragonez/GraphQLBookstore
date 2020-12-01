using GraphQL.Types;
using GraphQLBookstore.Models;

namespace GraphQLBookstore.GraphQL.Types
{
    class MessageType : ObjectGraphType<Message>
    {
        public MessageType()
        {
            Field(o => o.Subject);
            Field(o => o.Body);
        }
    }
}