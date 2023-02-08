using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using RabbitMQ.Client;
using RabitMqApi.Services.Interfaces;

namespace RabitMqApi.Services.Implementations
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IConfiguration _configuration;
        public MessagePublisher(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Publish<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration["RabbitMq:HostName"],
                UserName = _configuration["RabbitMq:UserName"],
                Password = _configuration["RabbitMq:Password"],
                VirtualHost = "/"
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();
            channel.QueueDeclare("user", true, true);

            var messageJson = JsonSerializer.Serialize(message);
            var messageToSend = Encoding.UTF8.GetBytes(messageJson);

            channel.BasicPublish("", "user", body: messageToSend);
        }
    }
}
