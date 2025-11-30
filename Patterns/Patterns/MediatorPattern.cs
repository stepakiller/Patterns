using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public interface IChatMediator
    {
        void RegisterUser(IChatMember user);
        void SendMessage(string message, IChatMember sender);
    }
    public interface IChatMember
    {
        string Name { get; }
        void Send(string message);
        void Receive(string message, IChatMember sender);
    }

    public class ChatRoom : IChatMediator
    {
        private List<IChatMember> _users = new List<IChatMember>();

        public void RegisterUser(IChatMember user)
        {
            if (!_users.Contains(user))
            {
                _users.Add(user);
                Console.WriteLine($"{user.Name} присоединился к чату.");
            }
        }

        public void SendMessage(string message, IChatMember sender)
        {
            foreach (var user in _users) if (user != sender) user.Receive(message, sender);
        }
    }

    public class ChatUser : IChatMember
    {
        private IChatMediator _mediator;
        public string Name { get; }

        public ChatUser(string name, IChatMediator mediator)
        {
            Name = name;
            _mediator = mediator;
            _mediator.RegisterUser(this);
        }

        public void Send(string message)
        {
            Console.WriteLine($"{Name} отправляет: {message}");
            _mediator.SendMessage(message, this);
        }

        public void Receive(string message, IChatMember sender) => Console.WriteLine($"{Name} получает от {sender.Name}: {message}");
    }
}
