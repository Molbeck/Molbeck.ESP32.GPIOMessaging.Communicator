using Molbeck.ESP32.GPIOMessaging.Model.Configurations;

namespace Molbeck.ESP32.GPIOMessaging.RuntimeConfiguration.Configurations
{
   public class BlueLEDGpioConfiguration : IGpioConfiguration
   {
      /// <inheritdoc />
      public string Description => "The blue light on the ESP32";

      /// <inheritdoc />
      public int Pin => 2;
   }
}