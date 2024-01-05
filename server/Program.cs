using RabbitMQ;
using RabbitMQ.Client;
using System.Text;


string? name = Console.ReadLine();
string? firstName = Console.ReadLine();

var factory = new ConnectionFactory() { HostName="localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(
        queue:"asp-net",
        durable:false,
        exclusive:false,
        autoDelete:false,
        arguments:null
        );
    string message = name+" "+firstName;
    
    channel.BasicPublish(exchange:"",
                         routingKey:"asp-net",
                         basicProperties:null,
                         body:Encoding.UTF8.GetBytes(message));
}
 
