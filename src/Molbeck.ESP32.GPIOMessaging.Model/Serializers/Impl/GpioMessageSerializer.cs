using System.Text;

namespace Molbeck.ESP32.GPIOMessaging.Model.Serializers.Impl
{
   public class GpioMessageSerializer : IGpioMessageSerializer
   {
      public byte[] Serialize(GpioMessage message)
      {
         //ESP is working with Maps. Convert the message to a map
         var stringBuilder = new StringBuilder("{");
         stringBuilder.Append($"\"pin\":\"{message.Pin}\"");
         stringBuilder.Append(",");
         stringBuilder.Append($"\"value\":{message.Value}");
         if (message.ResetTime != null)
         {
            stringBuilder.Append(",");
            stringBuilder.Append($"\"resetTime\":{message.ResetTime}");
         }

         stringBuilder.Append("}");
         var encoded = Encoding.UTF8.GetBytes(stringBuilder.ToString());
         return encoded;
      }
   }
}