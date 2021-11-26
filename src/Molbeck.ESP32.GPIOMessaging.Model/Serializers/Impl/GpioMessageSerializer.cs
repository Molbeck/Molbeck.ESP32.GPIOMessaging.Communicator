using System.Text;

namespace Molbeck.ESP32.GPIOMessaging.Model.Serializers.Impl
{
   public class GpioMessageSerializer : IGpioMessageSerializer
   {
      public byte[] Serialize(GpioMessage message)
      {
         //ESP is working with Maps. Convert the message to a map
         var stringBuilder = new StringBuilder("{");
         stringBuilder.Append($"\"pin\":{message.Pin}");
         stringBuilder.Append(",");
         int value = (int)message.Value;
         stringBuilder.Append($"\"value\":{value}");
         if (message.WaitToResetTimeout != null)
         {
            stringBuilder.Append(",");
            stringBuilder.Append($"\"wait_to_reset_timeout\":{message.WaitToResetTimeout}");
         }

         stringBuilder.Append("}");
         var encoded = Encoding.UTF8.GetBytes(stringBuilder.ToString());
         return encoded;
      }
   }
}