using System;
using System.Collections.Generic;
using Rico.CQRS.Commands;
using Rico.CQRS.Exceptions;

namespace Rico.CQRS.Storage
{
    public class Bus:ICommandSender
    {
        private readonly Dictionary<Type, List<Action<Command>>> _handlers = new Dictionary<Type, List<Action<Command>>>();

        public Dictionary<Type, List<Action<Command>>> Handlers { get { return _handlers; }  }

        public void RegisterHandler<T>(Action<T> handler) where T : Command
        {
            List<Action<Command>> handlers;
            if (!_handlers.TryGetValue(typeof(T), out handlers))
            {
                
                handlers = new List<Action<Command>>();
                var cmd = Convert(handler);
                handlers.Add(cmd);
                _handlers.Add(typeof(T), handlers);
            }
            //handlers.Add(DelegateAdjuster.CastArgument<Message, T>(x => handler(x)));
        }

        public void Send<T>(T command) where T : Command
        {
            List<Action<Command>> handlers;
            if (_handlers.TryGetValue(typeof(T), out handlers))
            {
                if (handlers.Count != 1) throw new InvalidOperationException("cannot send to more than one handler");
                handlers[0](command);
            }
            else
            {
                throw new UnregisteredDomainCommandException("no handler registered");
            }
        }

        
        public Action<object> Convert<T>(Action<T> myActionT)
        {
            if (myActionT == null) return null;
            else return new Action<object>(o => myActionT((T)o));
        }
    }
}
