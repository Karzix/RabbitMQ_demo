using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.ConsoleApp.Model;

namespace RabbitMQ.ConsoleApp.Service
{
    public class RabbitMQClientService
    {
        private readonly RabbitMQSettings _rabbitMQSettings;

        public RabbitMQClientService(IOptions<RabbitMQSettings> rabbitMQSettings)
        {
            _rabbitMQSettings = rabbitMQSettings.Value;
        }

        public IConnection GetRabbitMQConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = _rabbitMQSettings.HostName,
                UserName = _rabbitMQSettings.UserName,
                Password = _rabbitMQSettings.Password,
                VirtualHost = _rabbitMQSettings.VirtualHost,
                Port = _rabbitMQSettings.Port
            };

            return factory.CreateConnection();
        }
    }
}
