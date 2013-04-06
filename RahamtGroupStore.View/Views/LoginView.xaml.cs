using System;
using System.Windows;
using System.Windows.Input;
using RahamtGroupStore.View.Methods;
using RahamtGroupStore.View.Properties;
using RahamtGroupStore.ViewModel.ViewModel;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;
using RahamtGroupStore.View.Views;
namespace RahamtGroupStore.View.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            var loginvm = new LoginVm();
            loginvm.OnLoginSuccess+=LoginSuccessed;
            DataContext = loginvm;
        }

        private void LoginSuccessed()
        {
            if (LoginSuccess != null)
            {
                LoginSuccess();
            }
        }

        public delegate void LoginDoneSuccessfully();

        public event LoginDoneSuccessfully LoginSuccess;
    }
}