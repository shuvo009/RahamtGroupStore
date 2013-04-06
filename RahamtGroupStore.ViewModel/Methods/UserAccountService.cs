using RahamtGroupStore.Model.DatabaseModels;

namespace RahamtGroupStore.ViewModel.Methods
{
    public class UserAccountService
    {
        private static UserAccountService _userAccountService = null;

        private UserAccountService()
        {
        }

        public UserAccount UserAccount { get; set; }

        public static UserAccountService GetService
        {
            get { return _userAccountService ?? (_userAccountService = new UserAccountService()); }
        }
    }
}