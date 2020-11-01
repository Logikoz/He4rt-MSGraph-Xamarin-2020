using MSGraph.Mobile.Models;

using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MSGraph.Mobile.ViewModels
{
	public class EmailsSentViewModel
	{
		public ObservableCollection<EmailSentModel> Emails { get; } = new ObservableCollection<EmailSentModel>();

		public async Task GetEmailsAsync()
		{
			Emails.Clear();

			App.GraphClient.BaseUrl = "https://graph.microsoft.com/v1.0";
			var events = await App.GraphClient.Me.Messages.Request()
				.OrderBy("sentDateTime DESC")
				.Top(20)
				.GetAsync();

			events.CurrentPage.Select(e => new EmailSentModel
			{
				Email = e.ToRecipients.FirstOrDefault()?.EmailAddress?.Address,
				Subject = e.Subject,
				DateTime = e.SentDateTime.Value.DateTime
			}).ToList().ForEach(email => Emails.Add(email));
		}
	}
}