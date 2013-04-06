using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;
using RahamtGroupStore.ViewModel.Methods;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class CreateUserAccountVm : GenericViewModel<UserAccount>
    {
        public CreateUserAccountVm() : base("Create User Account")
        {
            InitialData();
            DeleteCommand = new RelayCommand<UserAccount>(DeleteCommandExecute, DeleteCommandCanExecute);
        }

        public new RelayCommand<UserAccount> DeleteCommand { get; set; }


        public override void UpdateCommandExecute(UserAccount entity)
        {
            if (DataRepository.IsEntityExists(x => x.UserName.Equals(entity.UserName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Username already Used", SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
                DataRepository.ClearChanges(entity);
                return;
            }
            entity.UserPassword = MiraculousMethods.Sha256Encrypt(entity.UserPassword);
            base.UpdateCommandExecute(entity);
        }

        public override bool CommandCanExecute(UserAccount entity)
        {
            try
            {
                return !(String.IsNullOrEmpty(entity.UserName) || String.IsNullOrEmpty(entity.UserPassword) || !entity.UserPassword.Equals(entity.ConformPassword));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCommandCanExecute(UserAccount entity)
        {
            try
            {
                return !(String.IsNullOrEmpty(entity.UserName));
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Helper
        private async void InitialData()
        {
            IsBusy = true;
            await Task.Factory.StartNew(() =>
            {
                ItemCollection = new ObservableCollection<UserAccount>(DataRepository.Search(x=>x.UserName!="Admin"));

                IsBusy = false;
            });
        }
        #endregion
    }
}