using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

namespace stock_api.RabbitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        private IConfiguration _configuration;

        public RabitMQProducer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendOrderMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(_configuration.GetSection("ConnectionRabbit").GetSection("HostName").Value),
                UserName = (_configuration.GetSection("ConnectionRabbit").GetSection("Username").Value),
                Password = (_configuration.GetSection("ConnectionRabbit").GetSection("Password").Value)
            };

            var connection = factory.CreateConnection();
 
            using var channel = connection.CreateModel();
            
            channel.QueueDeclare(
               queue: "Order",
               durable: false,
               exclusive: false,
               autoDelete: false,
               arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "Order", body: body);
        }
    }
}
