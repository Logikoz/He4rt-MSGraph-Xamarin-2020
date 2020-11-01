using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MSGraph.Mobile.Droid
{
	[Activity(MainLauncher = true, Theme = "@style/Splash", NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			StartActivity(typeof(MainActivity));
		}
	}
}