XamarinBasicSplashScreenNet7

Jan 26 2023

This is a Net7 version of the original XamarinBasicSplashScreen app. 
Visual Studio 2022 version used VS 2022 17.5.0 Preview 2.0

Target OS Version is 33 and supported OS Version is 24. Please note that it should run on all devices down to API 21. However I don't possess working devices less than Android 7.0 (24)

**How is it done?** 

There are two identical styles.xml files in Resource/values and and Resource/values-31. The values-31/styles.xml is not strictly necessary but I'm assuming that later versions of Android may require it if there are changes to the SplashScreen API.

These styles.xml contains the following
```				 
<style name="Theme.XamarinBasicSplashScreen.Starting" parent="Theme.SplashScreen.IconBackground">
	<item name="windowSplashScreenAnimatedIcon">@mipmap/appicon_foreground</item>
	<item name="windowSplashScreenIconBackgroundColor">@color/ic_launcher_background</item>
	<item name="windowSplashScreenBackground">?android:colorBackground</item>
	<item name="postSplashScreenTheme">@style/Theme.XamarinBasicSplashScreen</item>
</style>
 ```
 To break it down the parent theme is the SplashScreen API’s Theme.SplashScreen.IconBackGround and so our theme Theme.XamarinBasicSplashScreen.Starting inherits from that. The term “Starting” is an Android recommendation. When the splash screen is done the theme is changed by the postSplashScreenTheme value which comes from the style name Theme.XamarinBasicSplashScreen in Themes.xml. This is the reason why the Activity Attribute doesn’t have a theme attribute. Now check the AndroidManifest and you find that android:theme is set as  android:theme="@style/Theme.XamarinBasicSplashScreen.Starting".


The only other change is the addition of one line to the OnCreate of the MainActivity. Add the following line before base.OnCreate(savedInstanceState).
```
AndroidX.Core.SplashScreen.SplashScreen.InstallSplashScreen(this);
```
This is what you would call a basic splash screen it can be more sophisticated such as keeping the splash screen on-screen for longer periods and you can customize the animation for dismissing the splash screen. It can also have a branding image.

Personally, I think the shorter the time the splash screen is displayed the better. Any app I write aims to have the fastest possible start time. I’m sure most Xamarin users would remember the  Xamarin.Forms demo apps where the start time could be measured in seconds. That may be ok for enterprise apps, but I doubt any user would be satisfied with an app that takes longer to start than say any of the standard apps supplied by Google.

Use the Android’s logcat to measure how fast it is by looking for the expression “displayed”.

On a Pixel 6 (Android 13) this app returns between 155 to 173ms. Admittedly this is a very small app, but my published apps all return sub ½ second displayed times.  Just remember when testing, each time you run the app to remove it from memory via your Recents, so that you are doing a cold start each time you launch the app.

Just a note about that AndroidManifest.xml in your project. The file you edit in your project is not the final AndroidManifest. During the build process the manifest is rebuild as various stages during the build. So you should always check the final AndroidManifest. The file can be viewed in the obj/Debug or obj/Release folder of your project. For example obj\Release\net7.0-android\android\androidmanifest.xml   

Use the following link for more information on the SplashScreen API https://developer.android.com/develop/ui/views/launch/splash-screen

The following line of code is required for devices containing a camera notch. Comment out and rotate the screen to see why.
```
if (OperatingSystem.IsAndroidVersionAtLeast(28))
                Window!.Attributes!.LayoutInDisplayCutoutMode = LayoutInDisplayCutoutMode.Default;
```
**Bonus**

There is also a bonus with this demo app. If you are running an Android 13 device, you will also see Android’s new Predictive Back Gesture animation when you exit the app. 

If you check the manifest you will see a new entry in the Application tag *android:enableOnBackInvokedCallback="true".* 
Since this is still a future feature to be made available at a later date you must activate it via Developer options. Settings > System > Developer options and turn on Predictive back animations. When you swipe either left or right to exit the app you will see the animation.

To see the full effect, create a shortcut for the app, by moving it to the Home screen. That will enable the full shrinking animation. Use the following link for more info https://developer.android.com/guide/navigation/predictive-back-gesture. 