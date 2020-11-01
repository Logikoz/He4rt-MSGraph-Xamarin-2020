using Microsoft.Graph;
using Microsoft.Identity.Client;

using MSGraph.Mobile.Helpers;
using MSGraph.Mobile.Views;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MSGraph.Mobile
{
	public partial class App : Xamarin.Forms.Application, INotifyPropertyChanged
	{
		public static object AuthUIParent = null;
		public static string iOSKeychainSecurityGroup = null;
		public static IPublicClientApplication PCA;
		public static GraphServiceClient GraphClient;

		public App()
		{
			InitializeComponent();

			var builder = PublicClientApplicationBuilder
				.Create(AuthSettings.ClientId)
				.WithRedirectUri(AuthSettings.RedirectUri);

			if (!string.IsNullOrEmpty(iOSKeychainSecurityGroup))
				builder = builder.WithIosKeychainSecurityGroup(iOSKeychainSecurityGroup);

			PCA = builder.Build();

			MainPage = new JoinPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}