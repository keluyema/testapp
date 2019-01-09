using ObjCRuntime;
using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TestApp
{
    public class AppInitializer
    {
        public static IApp StartApp(Xamarin.UITest.Platform platform)
        {           
            return ConfigureApp.iOS.StartApp();
        }
    }
}