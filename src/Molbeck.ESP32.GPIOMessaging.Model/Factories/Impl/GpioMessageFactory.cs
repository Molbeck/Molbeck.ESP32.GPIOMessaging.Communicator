using Molbeck.ESP32.GPIOMessaging.Model.Configurations;

namespace Molbeck.ESP32.GPIOMessaging.Model.Factories.Impl
{
   public class GpioMessageFactory : IGpioMessageFactory
   {
      /// <inheritdoc />
      public GpioMessage Create(IGpioConfiguration configuration, PinValue value, int? resetTime = null)
      {
         return new GpioMessage(configuration.Pin, value, resetTime);
      }
   }
}