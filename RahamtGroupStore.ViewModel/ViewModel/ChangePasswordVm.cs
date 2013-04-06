using System;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;
using RahamtGroupStore.ViewModel.Methods;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class ChangePasswordVm : GenericViewModel<UserAccount>
    {
        private string _oldPassword;

        public ChangePasswordVm()
            : base("Change Password")
        {
        }

        public string OldPassword
        {
            get { return _oldPassword; }
            set
            {
                _oldPassword = value;
                OnPeroertyChange("OldPassword");
            }
        }

        public override void UpdateCommandExecute(UserAccount entity)
        {
            entity.UserName = UserAccountService.GetService.UserAccount.UserName;
            entity.Id = UserAccountService.GetService.UserAccount.Id;
            entity.UserPassword = MiraculousMethods.Sha256Encrypt(entity.UserPassword);
            base.UpdateCommandExecute(entity);
        }


        public override bool CommandCanExecute(UserAccount entity)
        {

            try
            {
                return !(String.IsNullOrEmpty(entity.UserPassword) || String.IsNullOrEmpty(entity.ConformPassword))
               && MiraculousMethods.Sha256Encrypt(entity.UserPassword).Equals(MiraculousMethods.Sha256Encrypt(entity.ConformPassword))
               && MiraculousMethods.Sha256Encrypt(OldPassword).Equals(UserAccountService.GetService.UserAccount.UserPassword);

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}