namespace Molbeck.ESP32.GPIOMessaging.RuntimeConfiguration
{
   public interface IToitSubscriptionConfiguration
   {
      public string Topic { get; }
      public string Address { get; }
      public string Key { get; }
   }
}