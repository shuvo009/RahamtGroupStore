using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RahamtGroupStore.Model;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class StockRegisterVm : SearchWithPrint<StockRegister>
    {
        public StockRegisterVm()
            : base("Stock Register")
        {
        }

        public override bool CommandCanExecute(StockRegister entity)
        {
            throw new NotImplementedException();
        }

        protected async override void SearchCommandExecute(StockRegister entity)
        {
            try
            {
                IsBusy = true;
                await Task.Factory.StartNew(
                      () =>
                      {
                          ItemCollection =
                              new ObservableCollection<StockRegister>(
                                 DataRepository.Search(x => x.EntryDate >= entity.EntryDate && x.EntryDate <= SecondDate).OrderByDescending(x => x.EntryDate));
                          IsBusy = false;
                      });
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[15], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void ResetCommandExecute(StockRegister entity)
        {
            entity.EntryDate = SecondDate = DateTime.Today;
            ItemCollection = null;
        }

        protected override bool SearchCommandCanExecute(StockRegister entity)
        {
            return true;
        }
    }
}