using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace APP
{
    public static class Constants
    {
        public static string BaseURL = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7093" : "https://localhost:5093";
        public static string UsuariosURL = $"{BaseURL}/api/Usuario";
    }
}
