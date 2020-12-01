using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace GraphQLBookstore.Models
{
    class Chat : IChat
    {
        private readonly ISubject<Message> _messageStream = new ReplaySubject<Message>(1);

        public Message AddMessage(Message message)
        {
            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<Message> Messages()
        {
            return _messageStream.AsObservable();
        }
    }
}