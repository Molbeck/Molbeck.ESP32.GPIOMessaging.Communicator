using System.Text;

namespace Molbeck.ESP32.GPIOMessaging.Model.Serializers
{
   public class GpioMessageSerializer
   {
      public byte[] Serialize(GpioMessage message)
      {
         //ESP is working with Maps. Convert the message to a map
         var jsonMap = $"{{\"pin\":\"{message.Pin}\", \"value\":{message.Value} ,\"resetTime\":{message.ResetTime}}}";
         var encoded = Encoding.UTF8.GetBytes(jsonMap);
         return encoded;
      }
   }
}