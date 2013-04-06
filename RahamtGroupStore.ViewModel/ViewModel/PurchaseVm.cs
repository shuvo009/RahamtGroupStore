using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using RahamtGroupStore.Model;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;
using System.Data;
using RahamtGroupStore.ViewModel.Methods;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class PurchaseVm : WithCartOperations<StockRegister>
    {
        #region Delegates

        public delegate void SupplierInfo();

        #endregion

        public PurchaseVm() : base("Purchase")
        {
            CreateNewItems();
            GetSupplierInfoCommand = new RelayCommand<StockRegister>(GetSupplierInfoExecute);
            Messenger.Default.Register(this, new Action<SupplierInformation>(suplierInfo =>
                                                                   {
                                                                       SelectedItem.
                                                                           SupplierInformation =
                                                                           DataRepository.GetSupplierInfoById(suplierInfo.Id);
                                                                   }));
            Messenger.Default.Register(this, new Action<SparesInformation>(sparesInfo =>
                                                                               {
                                                                                   SelectedItem.
                                                                                       SparesInformation =DataRepository.GetSparesInfoById(sparesInfo.Id);
                                                                               }));
        }

        public RelayCommand<StockRegister> GetSupplierInfoCommand { get; set; }
        public event SupplierInfo GetSupplierInfo;

        public override void UpdateCommandExecute(StockRegister entity)
        {
            try
            {
                DataRepository.UpdateStockRegister(ItemCollection);
                MessageBox.Show(ErrorMessage[1], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Information);
                NewCommandExecute(entity);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[0], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetSupplierInfoExecute(StockRegister stockRegister)
        {
            try
            {
                if (GetSupplierInfo != null)
                {
                    GetSupplierInfo();
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[14], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override void NewCommandExecute(StockRegister entity)
        {
            base.NewCommandExecute(entity);
            CreateNewItems();
        }

        public override bool CommandCanExecute(StockRegister entity)
        {
            try
            {
                return ItemCollection.Any();
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected override bool CartCanExecute(StockRegister entity)
        {
            try
            {
                return !(String.IsNullOrEmpty(entity.InvoiceNumber) ||
                               entity.Quantity <= 0 ||
                               entity.SparesInformation == null ||
                               entity.SupplierInformation == null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void CreateNewItems()
        {
             ItemCollection = new ObservableCollection<StockRegister>();
        }
    }
}