using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Messaging.ServiceBus;

namespace InfinityAZ
{
    public static class InfinityAZ
    {
        [FunctionName("InfinityAZ")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            await SendQueueMessage("Gavin,Baker,endhousesoftware999@gmail.com,ID45");

            string responseMessage = "This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        public static async Task SendQueueMessage(string msg)
        {
            // connection string to your Service Bus namespace
            string connectionString = "Endpoint=sb://endhousesoftware.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=n2epOdHF2rE5VNQmVVoyHiYbu5oFT2hq4Q29HzHmD6c=";

            // name of your Service Bus queue
            string queueName = "ehsqueue";

            // the client that owns the connection and can be used to create senders and receivers
            ServiceBusClient client;

            // the sender used to publish messages to the queue
            ServiceBusSender sender;

            // Create the clients that we'll use for sending and processing messages.
            client = new ServiceBusClient(connectionString);
            sender = client.CreateSender(queueName);

            // create a batch 
            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

            // try adding a message to the batch
            if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {msg}")))
            {
                // if it is too large for the batch
                throw new Exception($"The message is too large to fit in the batch.");
            }

            try
            {
                // Use the producer client to send the batch of messages to the Service Bus queue
                await sender.SendMessagesAsync(messageBatch);
                Console.WriteLine($"A messages {msg} has been published to the queue.");
            }
            finally
            {
                // Calling DisposeAsync on client types is required to ensure that network
                // resources and other unmanaged objects are properly cleaned up.
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}
