namespace Molbeck.ESP32.GPIOMessaging.Model.Serializers
{
   public interface IGpioMessageSerializer
   {
      byte[] Serialize(GpioMessage message);

   }
}