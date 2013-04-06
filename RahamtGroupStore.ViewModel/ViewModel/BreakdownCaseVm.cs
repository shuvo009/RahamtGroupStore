using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using RahamtGroupStore.Model;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;
using System.Windows;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class BreakdownCaseVm : GenericViewModel<BreakdownCause>
    {
        public BreakdownCaseVm()
            : base("Breakdown Cause")
        {
            InitialData();
        }

        public override void UpdateCommandExecute(BreakdownCause entity)
        {
            if (DataRepository.IsEntityExists(x => x.Cause.Equals(entity.Cause,StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(string.Format(ErrorMessage[16], "Breakdown cause"), SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
                DataRepository.ClearChanges(entity);
                return;
            }

            base.UpdateCommandExecute(entity);
        }
        public override bool CommandCanExecute(BreakdownCause entity)
        {
            try
            {
                return !String.IsNullOrEmpty(entity.Cause);
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
                        ItemCollection =new ObservableCollection<BreakdownCause>(DataRepository.GetAll().OrderBy(x => x.Cause));
                        IsBusy = false;
                    });
        }

        #endregion
    }
}