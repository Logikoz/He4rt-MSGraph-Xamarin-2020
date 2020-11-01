using System;

using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MSGraph.Mobile.UWP
{
	sealed partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			Suspending += OnSuspending;

			UnhandledException += async (sender, e) =>
			{
				e.Handled = true;

				await new MessageDialog(
					$"We are sorry, but something just went very very wrong, trying to save your work. \n\nError: {e.Message}",
					"🙈 App Blow Up Sky High")
				.ShowAsync();
			};
		}

		protected override void OnLaunched(LaunchActivatedEventArgs e)
		{
			if (!(Window.Current.Content is Frame rootFrame))
			{
				rootFrame = new Frame();

				rootFrame.NavigationFailed += OnNavigationFailed;

				Xamarin.Forms.Forms.Init(e);

				Window.Current.Content = rootFrame;
			}

			if (rootFrame.Content == null)
				rootFrame.Navigate(typeof(MainPage), e.Arguments);

			Window.Current.Activate();
		}

		private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
		}

		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();
			deferral.Complete();
		}
	}
}