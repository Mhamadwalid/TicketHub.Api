using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using TicketHub.Api.Models;

namespace TicketHub.Api.Services
{
    public class QueueService
    {
        private readonly string _connectionString;
        private readonly string _queueName;

        public QueueService(IConfiguration configuration)
        {
            _connectionString = configuration["AzureStorage:ConnectionString"];
            _queueName = configuration["AzureStorage:QueueName"];
        }

        public async Task SendMessageAsync(PurchaseRequest request)
        {
            var client = new QueueClient(_connectionString, _queueName);
            await client.CreateIfNotExistsAsync();

            if (client.Exists())
            {
                string message = JsonSerializer.Serialize(request);
                await client.SendMessageAsync(message);
            }
        }
    }
}
