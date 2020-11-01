using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MSGraph.Mobile.Utils
{
	public class NotifierUtil : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void Set<TObject>(ref TObject @object, TObject newObjectValue, [CallerMemberName] string property = null)
		{
			@object = newObjectValue;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}
	}
}