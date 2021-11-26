using System.Threading.Tasks;
using Molbeck.ESP32.GPIOMessaging.Model;
using Molbeck.ESP32.GPIOMessaging.Model.Factories.Impl;
using Molbeck.ESP32.GPIOMessaging.Model.Serializers.Impl;
using Molbeck.ESP32.GPIOMessaging.Model.Services.Impl;
using Molbeck.ESP32.GPIOMessaging.RuntimeConfiguration;

namespace Molbeck.GPIOMessaging.Demo
{
   public class Program
   {
      private static async Task Main(string[] args)
      {
         //Setup
         var serializer = new GpioMessageSerializer();
         var toitSubscriptionConfiguration = SetupConfigurations.GetTriggerMessageToitSubscription();
         var factory = new GpioMessageFactory();
         var service = new GpioService(serializer);
         var callCredentials = SetupConfigurations.SetupCallCredentials(toitSubscriptionConfiguration);
         var blueLedMessageConfig = SetupConfigurations.GetBlueLedGpioConfiguration();
         //Create message
         var message = factory.Create(blueLedMessageConfig, PinValue.High, 10000);

         //Send a new message
         await service.SendGpioMessage(message, toitSubscriptionConfiguration, callCredentials);
      }
   }
}