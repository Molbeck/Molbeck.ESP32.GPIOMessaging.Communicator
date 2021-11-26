using Molbeck.ESP32.GPIOMessaging.Model.Configurations;

namespace Molbeck.ESP32.GPIOMessaging.Model.Factories
{
   public interface IGpioMessageFactory
   {
      GpioMessage Create(IGpioConfiguration configuration, int value, int? resetTime = null);
   }
}