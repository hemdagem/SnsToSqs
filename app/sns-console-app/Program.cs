using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Task.WaitAll(SendMessage(builder.Build()));

        }

        static async Task SendMessage(IConfiguration configuration)
        {
            var options = configuration.GetAWSOptions();
            IAmazonSimpleNotificationService client = options.CreateServiceClient<IAmazonSimpleNotificationService>();

            var request = new ListTopicsRequest();
            var response =  await client.ListTopicsAsync(request);
            foreach (var responseTopic in response.Topics)
            {
                PublishRequest prequest = new PublishRequest(responseTopic.TopicArn, "hemang");

                var result = await client.PublishAsync(prequest);

                Console.Write(result.HttpStatusCode);
            }

            Console.ReadLine();
        }


    }
}
