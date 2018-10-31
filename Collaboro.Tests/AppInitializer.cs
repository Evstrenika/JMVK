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
                IApp app = ConfigureApp
                .Android
                .ApkFile("../../../AndroidProject/bin/Debug/android.apk")
                .StartApp();
                return app;    //ConfigureApp.Android.StartApp()
            }

            


            return ConfigureApp.iOS.StartApp();
        }
    }
}