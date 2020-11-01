namespace MSGraph.Mobile.Utils
{
	public enum MenuItemType
	{
		Welcome,
		Contacts,
		EmailsSent
	}

	public class NavMenuItem
	{
		public MenuItemType Id { get; set; }

		public string Title { get; set; }
	}
}