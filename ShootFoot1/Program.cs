using System;

namespace ShootFoot1
{
    interface IMessage
    {
        Type Type { get; }
        object Data { get; }
    }

    class Message : IMessage
    {
        public Type Type { get; set; }
        public object Data { get; set; }
    }

    class Sender
    {
        public void Send(Message message)
        {
            // ...do actual sending here...
            Console.WriteLine($"Send: Type={message.Type.Name}, Data={message.Data}");
        }
    }

    static class SenderExtensions
    {
        // Rename this method to SendObject() for safer programming
        public static void Send<T>(this Sender sender, T data)
        {
            sender.Send(new Message {Type = typeof(T), Data = data});
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sender = new Sender();
            sender.Send(42);

            var message = new Message {Type = typeof(int), Data = 42};
            sender.Send(message); // prints Send: Type=Int32, Data=42

            var iMessage = (IMessage) message;
            sender.Send(iMessage); // oops! Type=IMessage, Data=ShootFoot1.Message
        }
    }
}
