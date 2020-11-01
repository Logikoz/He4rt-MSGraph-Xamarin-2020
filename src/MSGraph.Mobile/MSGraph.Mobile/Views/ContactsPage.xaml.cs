using Microsoft.Graph;

using MSGraph.Mobile.ViewModels;

using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSGraph.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactsPage : ContentPage
	{
		public ContactsPage()
		{
			InitializeComponent();

			BindingContext = new ContactsViewModel();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			await (BindingContext as ContactsViewModel).GetContactsAsync();
		}
	}
}