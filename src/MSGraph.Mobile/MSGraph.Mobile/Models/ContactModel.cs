using Microsoft.Graph;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace MSGraph.Mobile.Models
{
	public class ContactModel
	{
		public string Name { get; set; }
		public string Number { get; set; }
		public string Email { get; set; }

		public ICommand SentEmailCommand { get; private set; }

		public ContactModel()
		{
			SentEmailCommand = new Command(async () => await SentEmailAsync());
		}

		private async Task SentEmailAsync()
		{
			if (await App.Current.MainPage.DisplayAlert("Confirm", $"Do you really want to send the invitation to {Email}?", "Yes", "No"))
			{
				await App.GraphClient.Me.SendMail(new Message
				{
					ToRecipients = new List<Recipient> { new Recipient { EmailAddress = new EmailAddress { Address = Email } } },
					Subject = "Invitation for He4rt Developers",
					Body = new ItemBody { Content = "<a href=\"https://heartdevs.com\">Come on meet the best developer community!</a>", ContentType = BodyType.Html }
				}).Request().PostAsync();

				await App.Current.MainPage.DisplayAlert("Invite Sent!", $"Invitation sent successfully for {Email}", "Ok");
			}
		}
	}
}