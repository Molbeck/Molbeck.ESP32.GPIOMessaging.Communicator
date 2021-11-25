using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;
using Grpc.Net.Client;
using Molbeck.ESP32.GPIOMessaging.Model;
using Molbeck.ESP32.GPIOMessaging.Model.Serializers;
using Molbeck.ESP32.GPIOMessaging.RuntimeConfiguration;
using Toit.Proto.API.PubSub;

namespace Molbeck.GPIOMessaging.Demo
{
   public class Program
   {
      private static async Task Main(string[] args)
      {
         var serializer = new GpioMessageSerializer();
         var config = SetupConfigurations.GetGpioTriggerMessageToitSubscription();
         //TODO: Move ths
         var callCredentials = CallCredentials.FromInterceptor((_, metadata) =>
         {
            metadata.Add("Authorization", $"Bearer {config.Key}");
            return Task.CompletedTask;
         });
         //TODO: Move this
         var channelCredentials = ChannelCredentials.Create(new SslCredentials(), callCredentials);
         using var channel = GrpcChannel.ForAddress(config.Address,
            new GrpcChannelOptions
            {
               Credentials = channelCredentials
            });

         //TODO: Move this
         var client = new Publish.PublishClient(channel);
         var message = new GpioMessage { Pin = "1", Value = 22 };
         var encoded = serializer.Serialize(message);
         //TODO: Move this out to a service!
         var request = new PublishRequest
         {
            Topic = config.Topic,
            PublisherName = "Testing",
            Data = { ByteString.CopyFrom(encoded) }
         };
         await client.PublishAsync(request);
      }
   }
}