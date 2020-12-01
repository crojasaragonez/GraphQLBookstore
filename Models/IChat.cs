using System;
using System.Collections.Concurrent;

namespace GraphQLBookstore.Models
{
    public interface IChat
    {
        Message AddMessage(Message message);
        IObservable<Message> Messages();
    }
}