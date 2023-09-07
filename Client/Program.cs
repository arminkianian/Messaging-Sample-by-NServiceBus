// See https://aka.ms/new-console-template for more information
using Messages;
using NServiceBus;

Console.WriteLine("Hello, World!");
Console.Title = "Client";

var configuration = new EndpointConfiguration("Client");
configuration.SendFailedMessagesTo("Client.Error");
configuration.EnableInstallers();

var transport = configuration.UseTransport<RabbitMQTransport>();
transport.UseConventionalRoutingTopology(
    queueType: QueueType.Classic // Specify the queueType here
);
transport.ConnectionString("host=localhost");

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