using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;
using Grpc.Net.Client;
using Molbeck.ESP32.GPIOMessaging.Model.Configurations;
using Molbeck.ESP32.GPIOMessaging.Model.Serializers;
using Toit.Proto.API.PubSub;

namespace Molbeck.ESP32.GPIOMessaging.Model.Services.Impl
{
   public class GpioService : IGpioService
   {
      private readonly IGpioMessageSerializer gpioMessageSerializer;

      public GpioService(IGpioMessageSerializer gpioMessageSerializer)
      {
         this.gpioMessageSerializer = gpioMessageSerializer;
      }

      public async Task SendGpioMessage(GpioMessage message, IToitSubscriptionConfiguration subscriptionConfiguration, CallCredentials callCredentials)
      {
         var channelCredentials = ChannelCredentials.Create(new SslCredentials(), callCredentials);
         using var channel = GrpcChannel.ForAddress(subscriptionConfiguration.Address,
            new GrpcChannelOptions
            {
               Credentials = channelCredentials
            });

         var client = new Publish.PublishClient(channel);
         var encoded = gpioMessageSerializer.Serialize(message);
         var request = new PublishRequest
         {
            Topic = subscriptionConfiguration.Topic,
            PublisherName = $"{nameof(GPIOMessaging)}",
            Data = { ByteString.CopyFrom(encoded) }
         };
         await client.PublishAsync(request);
      }
   }
}