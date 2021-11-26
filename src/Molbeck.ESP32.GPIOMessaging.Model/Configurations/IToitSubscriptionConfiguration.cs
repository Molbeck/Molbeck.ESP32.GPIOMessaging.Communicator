namespace Molbeck.ESP32.GPIOMessaging.Model.Configurations
{
   public interface IToitSubscriptionConfiguration
   {
      public string Topic { get; }
      public string Address { get; }
      public string Key { get; }
   }
}