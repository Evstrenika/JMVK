using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Collaboro.Tests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.StartApp();
            }

            IApp app = ConfigureApp
                .Android
                .ApkFile("../../../Collaboro.Android/bin/Debug/android.apk")
                .StartApp();


            return ConfigureApp.iOS.StartApp();
        }
    }
}