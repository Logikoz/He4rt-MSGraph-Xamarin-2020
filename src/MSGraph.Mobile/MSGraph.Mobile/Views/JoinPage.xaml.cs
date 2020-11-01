using MSGraph.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSGraph.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JoinPage : ContentPage
	{
		public JoinPage()
		{
			InitializeComponent();

			BindingContext = new JoinViewModel();
		}
	}
}