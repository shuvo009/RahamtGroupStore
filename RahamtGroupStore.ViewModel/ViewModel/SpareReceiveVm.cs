using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class SpareReceiveVm : GenericViewModel<SendForRepair>
    {
        public SpareReceiveVm()
            : base("Spare Receive")
        {
            InitialData();
        }


        public int ReceiveQuan { get; set; }

        public override void UpdateCommandExecute(SendForRepair entity)
        {
            try
            {
                DataRepository.AddMachinLedger(new MachineLedger
                                                   {
                                                       EntryDate = DateTime.Today,
                                                       MachineInformation =entity.MachineBreakdownInformation.MachineInformation,
                                                       Parteculars = "Received",
                                                       Quantity = entity.ReceiveQuantity,
                                                       RequisitionNo = entity.RequsitionNo,
                                                       SparesInformation =entity.MachineBreakdownInformation.SparesInformation
                                                   });
                entity.ReceiveQuantity += entity.ReceivedQuantity;
                if (entity.SendQuantity <= entity.ReceiveQuantity)
                {
                    DataRepository.DeleteSendForRepairInfo(entity);
                    ItemCollection.Remove(entity);
                    MessageBox.Show(ErrorMessage[1], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    base.UpdateCommandExecute(entity);
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[0], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override void GridViewClickExecute(SendForRepair entity)
        {
            if (entity != null)
                entity.ReceivedQuantity = 0;

            base.GridViewClickExecute(entity);
        }

        public override bool CommandCanExecute(SendForRepair entity)
        {
            try
            {
                return entity.ReceivedQuantity > 0;
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
                        ItemCollection =
                            new ObservableCollection<SendForRepair>(
                                DataRepository.GetAll().OrderByDescending(x => x.EntryDate));
                        IsBusy = false;
                    });
        }

        #endregion
    }
}