using System;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;
using RahamtGroupStore.ViewModel.Methods;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class LoginVm : GenericViewModel<UserAccount>
    {
        #region Delegate

        public delegate void LoginSuccess();

        #endregion

        #region Event

        public event LoginSuccess OnLoginSuccess;

        #endregion

        public LoginVm()
            : base("Login")
        {
            LoginCommand = new RelayCommand<UserAccount>(LoginCommandExecute, CommandCanExecute);
            LoginButtonContent = "Login";
        }

        public RelayCommand<UserAccount> LoginCommand { get; private set; }
        public string LoginButtonContent { get; set; }


        public async void LoginCommandExecute(UserAccount entity)
        {
            try
            {
                IsBusy = true;
                await Task.Factory.StartNew(() =>
                                                {
                                                    var userAccount = DataRepository.Search(x => x.UserName.Equals(entity.UserName, StringComparison.CurrentCultureIgnoreCase) && x.UserPassword.Equals(x.UserPassword)).FirstOrDefault();
                                                    if (userAccount != null)
                                                    {
                                                        UserAccountService.GetService.UserAccount = userAccount;

                                                        if (OnLoginSuccess != null)
                                                        {
                                                            OnLoginSuccess();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("UserName or UserPassword Worng !", SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
                                                        entity.ClearAllProperty();
                                                    }
                                                    IsBusy = false;
                                                });
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error\nPlease Restart software.", SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
                entity.ClearAllProperty();
            }
        }

        public override bool CommandCanExecute(UserAccount entity)
        {
            try
            {
                return !(String.IsNullOrEmpty(entity.UserName) || String.IsNullOrEmpty(entity.UserPassword));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}