﻿using DevFreela.Core.IntegrationEvents;
using DevFreela.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DevFreela.Application.Consumers
{
    public class PaymentApprovedConsumer : BackgroundService
    {

        private const string PAYMENT_APPROVED_QUEUE = "PaymentsApproved";
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public PaymentApprovedConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: PAYMENT_APPROVED_QUEUE,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var paymentApprovedBytes = eventArgs.Body.ToArray();
                var paymentApprovedJson = Encoding.UTF8.GetString(paymentApprovedBytes);

                var paymentApprovedIntegrationEvent = JsonSerializer.Deserialize<PaymentApprovedIntegrationEvent>(paymentApprovedJson);

                await FinishProject(paymentApprovedIntegrationEvent.IdProject);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(PAYMENT_APPROVED_QUEUE, false, consumer);
        }

        private async Task FinishProject(int idProject)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var projectRepository = scope.ServiceProvider.GetRequiredService<IProjectRepository>();

                var project = await projectRepository.GetByIdAsync(idProject);

                project.Finish();

                await projectRepository.SaveChangesAsync();
            }
        }
    }
}