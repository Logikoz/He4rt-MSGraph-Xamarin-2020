using MSGraph.Mobile.Models;

using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MSGraph.Mobile.ViewModels
{
	public class ContactsViewModel
	{
		public ObservableCollection<ContactModel> Contacts { get; } = new ObservableCollection<ContactModel>();

		public async Task GetContactsAsync()
		{
			Contacts.Clear();

			App.GraphClient.BaseUrl = "https://graph.microsoft.com/v1.0";
			var events = await App.GraphClient.Me.Contacts.Request()
				.OrderBy("displayName")
				.Top(1000)
				.GetAsync();

			events.CurrentPage.Select(e => new ContactModel
			{
				Name = e.DisplayName,
				Number = e.MobilePhone,
				Email = e.EmailAddresses?.FirstOrDefault()?.Address
			}).ToList().ForEach(contact => Contacts.Add(contact));
		}
	}
}