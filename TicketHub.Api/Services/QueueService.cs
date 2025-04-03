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
            try
            {
                var client = new QueueClient(_connectionString, _queueName);
                await client.CreateIfNotExistsAsync();

                var exists = await client.ExistsAsync();

                if (await client.ExistsAsync())
                {
                    string message = JsonSerializer.Serialize(request);
                    await client.SendMessageAsync(message);
                }
                else
                {
                    Console.WriteLine("[ERROR] Queue does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[QUEUE ERROR] {ex.Message}");
                throw; // Let the controller return 500 if needed
            }
        }
    }
}
