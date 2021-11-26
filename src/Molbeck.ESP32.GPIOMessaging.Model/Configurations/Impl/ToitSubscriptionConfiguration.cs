namespace Molbeck.ESP32.GPIOMessaging.Model.Configurations.Impl
{
   public class ToitSubscriptionConfiguration : IToitSubscriptionConfiguration
   {
      public string Topic { get; set; }
      public string Address { get; set; }
      public string Key { get; set; }
   }
}