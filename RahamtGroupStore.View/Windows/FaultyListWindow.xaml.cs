using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace RahamtGroupStore.View.Windows
{
	/// <summary>
	/// Interaction logic for FaultyListWindow.xaml
	/// </summary>
	public partial class FaultyListWindow : Window
	{
		public FaultyListWindow()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
            faultylist.OnDoubleclickOnGridView += faultylist_OnDoubleclickOnGridView;
            Messenger.Default.Send(Visibility.Collapsed);
		}

        void faultylist_OnDoubleclickOnGridView()
        {
            Close();
        }
	}
}