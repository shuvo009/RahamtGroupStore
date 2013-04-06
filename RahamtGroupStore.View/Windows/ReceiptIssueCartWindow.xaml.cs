using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace RahamtGroupStore.View.Windows
{
	/// <summary>
	/// Interaction logic for ReceiptIssueCartWindow.xaml
	/// </summary>
	public partial class ReceiptIssueCartWindow : Window
	{
		public ReceiptIssueCartWindow()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
            receiptIssueCards.OnDoubleclickOnGridView += receiptIssueCards_OnDoubleclickOnGridView;
            Messenger.Default.Send(Visibility.Collapsed);
		}

        void receiptIssueCards_OnDoubleclickOnGridView()
        {
           Close();
        }
	}
}