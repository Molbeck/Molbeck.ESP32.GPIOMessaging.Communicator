namespace Molbeck.ESP32.GPIOMessaging.Model
{
   public class GpioMessage
   {
      public GpioMessage(int pin, PinValue value, int? waitToResetTimeout)
      {
         Pin = pin;
         Value = value;
         WaitToResetTimeout = waitToResetTimeout;
      }

      /// <summary>
      ///    The GPIO pin
      /// </summary>
      public int Pin { get; }

      /// <summary>
      ///    The value the pin should get
      /// </summary>
      public PinValue Value { get; }

      /// <summary>
      ///    The timeout in milliseconds before the pin should reset itself to the original value
      /// </summary>
      public int? WaitToResetTimeout { get; }
   }
}