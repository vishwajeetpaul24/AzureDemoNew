using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using AzureDemo.Models;
using Microsoft.Extensions.Azure;
using System.Text.Json;
namespace AzureDemo.Services
{
    public class AzureQueueService
    {
        private readonly string _connectionstring;
        private readonly string _queuename;
        public AzureQueueService(IConfiguration configuration)
        {
            _connectionstring = "DefaultEndpointsProtocol=https;AccountName=myazuredotnetmastery;AccountKey=hPI3AdfLQVZ3mORk7LxqR6ofjAcYwbC2pGj3jooGCOZQtLgI12Y0UzDi7EKhsjvywM8qvpExzcn8+AStj6VJlw==;EndpointSuffix=core.windows.net";
            _queuename = "myqueue"; 
        }
        public async Task SendMessageAsync(formData data)
        {
            // Create a QueueClient
            QueueClient queueClient = new QueueClient(_connectionstring, _queuename);

            // Ensure the queue exists
            await queueClient.CreateIfNotExistsAsync();

            if (queueClient.Exists())
            {
                // Serialize the message
                string messageText = JsonSerializer.Serialize(data);

                // Send the message to the queue
                await queueClient.SendMessageAsync(messageText);
            }
        }
    }
}
