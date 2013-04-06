using System;
using System.Windows;

namespace RahamtGroupStore.View.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            login.LoginSuccess += LoginSuccess;
        }

        private void LoginSuccess()
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                                                         {
                                                             new MainWindow().Show();
                                                             Close();
                                                         }));

        }
    }
}