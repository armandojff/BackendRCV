using System;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace RCVUcabBackend.Persistence.DAOs.MQ
{
    public class ProveedorMQ
    {

        public string _result;
      public void Producer(object message)
        {
            try
            {
                AppSettings config = new AppSettings();
                var factory = new ConnectionFactory
                {
                    Uri = new Uri(config.MQConnectionString)
                };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                channel.QueueDeclare(config.QueueString, durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish("", config.QueueString, null, body);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void Consumer()
        {
            try
            {
                AppSettings config = new AppSettings();
                var factory = new ConnectionFactory()
                {
                    Uri = new Uri(config.MQConnectionString)
                };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(config.QueueString, durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        this._result = message;
                    };
                    channel.BasicConsume(queue: config.QueueString,
                                         autoAck: true,
                                       consumer: consumer);

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string getResult()
        {
            return _result;
        }
    }
}