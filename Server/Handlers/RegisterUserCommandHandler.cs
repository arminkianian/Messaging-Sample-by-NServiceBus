using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Handlers
{
    public class RegisterUserCommandHandler : IHandleMessages<RegisterUserCommand>
    {
        public Task Handle(RegisterUserCommand message, IMessageHandlerContext context)
        {
            //throw new Exception("X"); for Delayed Retry Test

            Console.WriteLine($"Message Arrived: {message.Username}");
            return Task.CompletedTask;
        }
    }
}
