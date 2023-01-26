#XamarinBasicSplashScreenNet7
Jan 26 2023

This is a Net7 version of the original XamarinBasicSplashScreen app
Visual Studio 2022 version used VS 2022 17.5.0 Preview 2.0 

Target OS Version is 33 and supported OS Version is 24. Please note that it should run on all devices down to API 21. However I don't possess working devices less than Android 7.0 (24)

How is it done?
There are two identical styles.xml files in Resource/values and and Resource/values-31. The values-31/styles.xml is not strictly necessary but I'm assuming that later versions of Android may require it if there are changes to the SplashScreen API
These sttles.xml contains the following
'
<style name="Theme.XamarinBasicSplashScreen.Starting" parent="Theme.SplashScreen.IconBackground">
	<item name="windowSplashScreenAnimatedIcon">@mipmap/appicon_foreground</item>
	<item name="windowSplashScreenIconBackgroundColor">@color/ic_launcher_background</item>
	<item name="windowSplashScreenBackground">?android:colorBackground</item>
	<item name="postSplashScreenTheme">@style/Theme.XamarinBasicSplashScreen</item>
</style>
'

