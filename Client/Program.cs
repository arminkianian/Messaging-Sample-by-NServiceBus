// See https://aka.ms/new-console-template for more information
using Messages;

Console.WriteLine("Hello, World!");

Console.Title = "Client";
var configuration = new EndpointConfiguration("Client");
configuration.UseTransport<LearningTransport>();

var endpointInstance = Endpoint.Start(configuration).Result;

while (true)
{
    Console.WriteLine("Press any key to send command");
    Console.ReadLine();

    var command = new RegisterUserCommand
    {
        Username = Faker.Internet.UserName()
    };

    endpointInstance.Send("Server", command).Wait();
}