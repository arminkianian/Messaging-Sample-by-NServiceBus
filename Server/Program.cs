// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.Title = "Server";
var configuration = new EndpointConfiguration("Server");
configuration.SendFailedMessagesTo("Server.Error");
configuration.EnableInstallers();

var transport = configuration.UseTransport<RabbitMQTransport>();
transport.UseConventionalRoutingTopology(
    queueType: QueueType.Classic // Specify the queueType here
);
transport.ConnectionString("host=localhost");

var endpointInstance = Endpoint.Start(configuration).Result;

Console.WriteLine("Waiting for messages...");
Console.ReadLine();