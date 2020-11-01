using Microsoft.Graph;
using Microsoft.Identity.Client;

using MSGraph.Mobile.Helpers;
using MSGraph.Mobile.Utils;
using MSGraph.Mobile.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace MSGraph.Mobile.ViewModels
{
	public class JoinViewModel : NotifierUtil
	{
		public ICommand SignInCommand { get; private set; }

		public JoinViewModel()
		{
			SignInCommand = new Command(async () => await SignInAsync());
		}

		private async Task SignInAsync()
		{
			try
			{
				IEnumerable<IAccount> accounts = await App.PCA.GetAccountsAsync();

				AuthenticationResult silentAuthResult = await App.PCA.AcquireTokenSilent(AuthSettings.Scopes.Split(' '), accounts.FirstOrDefault()).ExecuteAsync();
			}
			catch (MsalUiRequiredException)
			{
				try
				{
					AcquireTokenInteractiveParameterBuilder interactiveRequest = App.PCA.AcquireTokenInteractive(AuthSettings.Scopes.Split(' '));

					if (App.AuthUIParent != null)
						interactiveRequest = interactiveRequest.WithParentActivityOrWindow(App.AuthUIParent);
					await interactiveRequest.ExecuteAsync();
				}
				catch (Exception ex)
				{
					await App.Current.MainPage.DisplayAlert("Authentication failed", $"{ex.Message}", "Ok");
				}
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Error", $"Authentication failed. See exception messsage for more details: {ex.Message}", "Ok");
			}

			await InitializeGraphClientAsync();
		}

		private async Task InitializeGraphClientAsync()
		{
			try
			{
				IEnumerable<IAccount> currentAccounts = await App.PCA.GetAccountsAsync();

				if (currentAccounts.Count() > 0)
				{
					App.GraphClient = new GraphServiceClient(new DelegateAuthenticationProvider(
						async (requestMessage) =>
						{
							AuthenticationResult result = await App.PCA.AcquireTokenSilent(AuthSettings.Scopes.Split(' '), currentAccounts.FirstOrDefault()).ExecuteAsync();

							requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
						}));

					App.Current.MainPage = new MainPage();
				}
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Error", $"Authentication failed. See exception messsage for more details: {ex.Message}", "Ok");
			}
		}
	}
}