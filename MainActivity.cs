using Android.App;
using Android.OS;
using Android.Views;
using AndroidX.AppCompat.App;
using System;

namespace XamarinBasicSplashScreenNet7
{
    [Activity(Label = "@string/app_name",  MainLauncher = true)]  // Theme = "@style/Theme.XamarinBasicSplashScreen", - Removed because of the SplashScreen API - see how the theme is set in the AndroidManifest.xml
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            AndroidX.Core.SplashScreen.SplashScreen.InstallSplashScreen(this);

            base.OnCreate(savedInstanceState);
            
            // Only for demonstration purposes so that you can easily get a good look at the launch icon to check the background colour - Remove for any normal build.
            //System.Threading.Thread.Sleep(2000);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Include this if using the Splash Screen API - rotate to Landscape on a device with a notch to see why - with this code commented.
            if (OperatingSystem.IsAndroidVersionAtLeast(28))
                Window!.Attributes!.LayoutInDisplayCutoutMode = LayoutInDisplayCutoutMode.Default;
        }
    }
}