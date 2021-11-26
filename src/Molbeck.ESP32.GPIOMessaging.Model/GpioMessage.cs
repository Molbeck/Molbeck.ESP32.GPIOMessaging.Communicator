using Molbeck.ESP32.GPIOMessaging.Model.Configurations;

namespace Molbeck.ESP32.GPIOMessaging.Model
{
   public class GpioMessage
   {
      public GpioMessage(string pin, int value, int? resetTime)
      {
         Pin = pin;
         Value = value;
         ResetTime = resetTime;
      }

      public string Pin { get; }
      public int Value { get; }
      public int? ResetTime { get; }
   }
}