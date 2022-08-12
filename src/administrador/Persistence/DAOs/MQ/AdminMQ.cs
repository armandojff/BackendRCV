﻿using System;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using administrador.BussinesLogic.DTOs;
namespace administrador.Persistence.DAOs.MQ

{
    public class AdminMQ
    {
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

        public string Consumer()
        {
            PagosDTO a=new PagosDTO();
            string response = "";
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
                        a.lt=message;
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
            return a.lt;
        }
    }
}