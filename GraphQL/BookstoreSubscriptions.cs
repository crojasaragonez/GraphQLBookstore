using System;
using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQLBookstore.Models;
using GraphQLBookstore.GraphQL.Types;

namespace GraphQLBookstore.GraphQL
{
    class BookstoreSubscriptions : ObjectGraphType
    {
        private readonly IChat _chat;
        public BookstoreSubscriptions(IChat chat)
        {
            _chat = chat;
            AddField(new EventStreamFieldType
            {
                Name = "messageAdded",
                Type = typeof(MessageType),
                Resolver = new FuncFieldResolver<Message>(ResolveMessage),
                Subscriber = new EventStreamResolver<Message>(Subscribe)
            });
        }

        private Message ResolveMessage(ResolveFieldContext<object> context)
        {
            var message = context.Source as Message;

            return message;
        }

        private IObservable<Message> Subscribe(ResolveFieldContext<object> context)
        {
            return _chat.Messages();
        }
    }
}