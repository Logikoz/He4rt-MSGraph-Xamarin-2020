using MSGraph.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSGraph.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmailsSentPage : ContentPage
	{
		public EmailsSentPage()
		{
			InitializeComponent();

			BindingContext = new EmailsSentViewModel();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			await (BindingContext as EmailsSentViewModel).GetEmailsAsync();
		}
	}
}