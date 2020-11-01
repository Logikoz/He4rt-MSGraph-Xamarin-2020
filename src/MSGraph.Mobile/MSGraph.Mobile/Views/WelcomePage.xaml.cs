using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSGraph.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage() => InitializeComponent();

		private void OpenMenu(object sender, EventArgs e)
		{
			(App.Current.MainPage as MasterDetailPage).IsPresented = true;
		}
	}
}