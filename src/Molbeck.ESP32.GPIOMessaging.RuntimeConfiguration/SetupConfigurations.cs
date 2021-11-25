namespace Molbeck.ESP32.GPIOMessaging.RuntimeConfiguration
{
   public class ToitSubscription
   {
        public string Topic { get; set; }
        public string Address { get; set; }
        public string Key { get; set; }
   }
   public class SetupConfigurations
   {

      public static ToitSubscription GetGpioTriggerMessageToitSubscription()
      {
         return new ToitSubscription()
         {
            Key = "9c002021277a3ef77f02842de6a3332a3eb87f11231128f36a27a2d96c0a1cdc",
            Address = "https://api.toit.io:443",
            Topic = "cloud:Testing001"
         };
      }
   }
}