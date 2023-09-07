// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.Title = "Server";
var configuration = new EndpointConfiguration("Server");
configuration.UseTransport<LearningTransport>();

var endpointInstance = Endpoint.Start(configuration).Result;

Console.WriteLine("Waiting for messages...");
Console.ReadLine();