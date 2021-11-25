using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;
using Grpc.Net.Client;
using Molbeck.ESP32.GPIOMessaging.Model;
using Molbeck.ESP32.GPIOMessaging.RuntimeConfiguration;
using Toit.Proto.API.PubSub;

namespace Molbeck.GPIOMessaging.Demo
{
   public class Program
   {
      private static async Task Main(string[] args)
      {
         var callCredentials = CallCredentials.FromInterceptor((_, metadata) =>
         {
            metadata.Add("Authorization", $"Bearer {SetupConfigurations.GPIO_Trigger_Subscription_Key}");
            return Task.CompletedTask;
         });
         var channelCredentials = ChannelCredentials.Create(new SslCredentials(), callCredentials);
         using var channel = GrpcChannel.ForAddress(SetupConfigurations.Toit_IO_Address,
            new GrpcChannelOptions
            {
               Credentials = channelCredentials
            });

         var client = new Publish.PublishClient(channel);
         var message = new GpioMessage(){ Pin = "1", Value = 22}
         var request = new PublishRequest
         {
            Topic = "cloud:Testing001",
            PublisherName = "Testing",
            Data = { ByteString.CopyFrom(message, Encoding.UTF8) }
         };
         await client.PublishAsync(request);
      }
   }
}