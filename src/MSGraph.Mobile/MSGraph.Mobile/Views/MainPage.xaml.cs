using MSGraph.Mobile.Utils;

using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MSGraph.Mobile.Views
{
	public partial class MainPage : MasterDetailPage
	{
		private readonly Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

		public MainPage()
		{
			InitializeComponent();

			MasterBehavior = MasterBehavior.Popover;

			MenuPages.Add((int)MenuItemType.Welcome, (NavigationPage)Detail);
		}

		public async Task NavigateFromMenu(int id)
		{
			if (!MenuPages.ContainsKey(id))
			{
				switch (id)
				{
					case (int)MenuItemType.Welcome:
						MenuPages.Add(id, new NavigationPage(new WelcomePage()));
						break;

					case (int)MenuItemType.Contacts:
						MenuPages.Add(id, new NavigationPage(new ContactsPage()));
						break;

					case (int)MenuItemType.EmailsSent:
						MenuPages.Add(id, new NavigationPage(new EmailsSentPage()));
						break;
				}
			}

			var newPage = MenuPages[id];

			if (newPage != null && Detail != newPage)
			{
				Detail = newPage;

				if (Device.RuntimePlatform == Device.Android)
					await Task.Delay(100);

				IsPresented = false;
			}
		}
	}
}