using System.Threading.Tasks;
using Grpc.Core;
using Molbeck.ESP32.GPIOMessaging.RuntimeConfiguration;

namespace Molbeck.ESP32.GPIOMessaging.Model.Services
{
   public interface IGpioService
   {
      Task SendGpioMessage(GpioMessage message, IToitSubscriptionConfiguration subscriptionConfiguration, CallCredentials callCredentials);
   }
}