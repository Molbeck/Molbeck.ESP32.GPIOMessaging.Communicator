namespace Molbeck.ESP32.GPIOMessaging.Model.Configurations
{
   public interface IGpioConfiguration
   {
      /// <summary>
      ///    A description of what this GPIO pin is set up to do
      /// </summary>
      string Description { get; }

      /// <summary>
      ///    The GPIO pin
      /// </summary>
      int Pin { get; }
   }
}