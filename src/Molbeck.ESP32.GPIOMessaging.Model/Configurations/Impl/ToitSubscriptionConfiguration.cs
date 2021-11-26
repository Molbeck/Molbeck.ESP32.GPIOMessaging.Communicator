namespace Molbeck.ESP32.GPIOMessaging.RuntimeConfiguration
{
   public class ToitSubscriptionConfiguration : IToitSubscriptionConfiguration
   {
      public string Topic { get; set; }
      public string Address { get; set; }
      public string Key { get; set; }
   }
}