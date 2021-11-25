using System;

namespace Molbeck.ESP32.GPIOMessaging.Model
{
    public class GpioMessage
    {
       public string Pin { get; set; }
       public int Value { get; set; }
       public int ResetTime  { get; set; }
    }
}
