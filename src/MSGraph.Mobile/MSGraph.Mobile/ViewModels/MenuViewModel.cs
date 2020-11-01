using Microsoft.Graph;
using Microsoft.Identity.Client;

using MSGraph.Mobile.Utils;
using MSGraph.Mobile.Views;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace MSGraph.Mobile.ViewModels
{
	public class MenuViewModel : NotifierUtil
	{
		private string __userName;
		private string __userEmail;
		private ImageSource __userPhoto;

		public string UserName
		{
			get => __userName;
			set => Set(ref __userName, value);
		}

		public string UserEmail
		{
			get => __userEmail;
			set => Set(ref __userEmail, value);
		}

		public ImageSource UserPhoto
		{
			get => __userPhoto;
			set => Set(ref __userPhoto, value);
		}

		public ICommand LogoutCommand { get; private set; }

		public MenuViewModel()
		{
			LogoutCommand = new Command(async () => await LogoutAsync());
		}

		public async Task GetUserInfoAsync()
		{
			User user = await App.GraphClient.Me.Request().GetAsync();

			UserName = user.DisplayName;
			UserEmail = string.IsNullOrEmpty(user.Mail) ? user.UserPrincipalName : user.Mail;
			UserPhoto = ImageSource.FromStream(() => GetUserPhoto());
		}

		private Stream GetUserPhoto()
		{
			App.GraphClient.BaseUrl = "https://graph.microsoft.com/beta";
			return App.GraphClient.Me.Photo.Content.Request().GetAsync().Result;
		}

		private async Task LogoutAsync()
		{
			if (await App.Current.MainPage.DisplayAlert("Logout", "Do you want to logout?", "Yes", "No"))
			{
				IEnumerable<IAccount> accounts = await App.PCA.GetAccountsAsync();

				while (accounts.Any())
				{
					await App.PCA.RemoveAsync(accounts.First());
					accounts = await App.PCA.GetAccountsAsync();
				}

				App.Current.MainPage = new JoinPage();
			}
		}
	}
}