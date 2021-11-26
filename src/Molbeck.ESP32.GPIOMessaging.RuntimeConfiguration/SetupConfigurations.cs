using System.Threading.Tasks;
using Grpc.Core;
using Molbeck.ESP32.GPIOMessaging.Model.Configurations;
using Molbeck.ESP32.GPIOMessaging.RuntimeConfiguration.Configurations;

namespace Molbeck.ESP32.GPIOMessaging.RuntimeConfiguration
{
   public class SetupConfigurations
   {
      public static CallCredentials SetupCallCredentials(ToitSubscriptionConfiguration config)
      {
         CallCredentials callCredentials = CallCredentials.FromInterceptor((_, metadata) =>
         {
            metadata.Add("Authorization", $"Bearer {config.Key}");
            return Task.CompletedTask;
         });
         return callCredentials;
      }

      public static IGpioConfiguration GetBlueLedGpioConfiguration()
      {
         return new BlueLEDGpioConfiguration();
      }

      public static ToitSubscriptionConfiguration GetGpioTriggerMessageToitSubscription()
      {
         return new ToitSubscriptionConfiguration()
         {
            Key = "9c002021277a3ef77f02842de6a3332a3eb87f11231128f36a27a2d96c0a1cdc",
            Address = "https://api.toit.io:443",
            Topic = "cloud:Testing001"
         };
      }
   }
}