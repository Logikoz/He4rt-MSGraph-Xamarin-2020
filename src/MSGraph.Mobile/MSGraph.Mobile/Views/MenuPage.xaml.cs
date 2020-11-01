using Microsoft.Graph;
using Microsoft.Identity.Client;

using MSGraph.Mobile.Utils;
using MSGraph.Mobile.ViewModels;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSGraph.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		private readonly List<NavMenuItem> menuItems;

		public MenuPage()
		{
			InitializeComponent();

			BindingContext = new MenuViewModel();

			menuItems = new List<NavMenuItem>
			{
				new NavMenuItem {Id = MenuItemType.Welcome, Title="Home" },
				new NavMenuItem {Id = MenuItemType.Contacts, Title="Contacts" },
				new NavMenuItem {Id = MenuItemType.EmailsSent, Title="Sented Emails" }
			};

			ListViewMenu.ItemsSource = menuItems;
			ListViewMenu.SelectedItem = menuItems[0];

			ListViewMenu.ItemSelected += async (sender, e) =>
			{
				if (e.SelectedItem == null)
					return;

				var id = (int)(e.SelectedItem as NavMenuItem).Id;

				await (App.Current.MainPage as MainPage).NavigateFromMenu(id);
			};
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			await (BindingContext as MenuViewModel).GetUserInfoAsync();
		}
	}
}