using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using RahamtGroupStore.Model;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;
using System.Windows;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class BreakdownTypeVm : GenericViewModel<BreakdownType>
    {
        public BreakdownTypeVm() : base("Breakdown Type Setup")
        {
            InitialData();
        }

        public override void UpdateCommandExecute(BreakdownType entity)
        {
            if (DataRepository.IsEntityExists(x => x.TypeName.Equals(entity.TypeName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(string.Format(ErrorMessage[16], "Breakdown Type"), SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
                DataRepository.ClearChanges(entity);
                return;
            }
            base.UpdateCommandExecute(entity);
        }
        public override bool CommandCanExecute(BreakdownType entity)
        {
            try
            {
                return !String.IsNullOrEmpty(entity.TypeName);
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
            await Task.Factory.StartNew(
                            () =>
                            {
                                ItemCollection = new ObservableCollection<BreakdownType>(DataRepository.GetAll().OrderBy(x => x.TypeName));
                                IsBusy = false;
                            });
        }

        #endregion
    }
}