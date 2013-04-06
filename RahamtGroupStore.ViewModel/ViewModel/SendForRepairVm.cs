using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class SendForRepairVm : GenericViewModel<SendForRepair>
    {
        public SendForRepairVm()
            : base("Send For Repair")
        {
            InitialData();

            Messenger.Default.Register(this, new Action<RepairCompaneyInformation>(repCompanyInfo =>
                                                                                       {
                                                                                           SelectedItem.RepairCompaneyInformation =
                                                                                               DataRepository.GetRepairCompanyById(repCompanyInfo.Id);
                                                                                       }));
            Messenger.Default.Register(this, new Action<MachineBreakdownInformation>(machBreakInfo =>
                                                                                         {
                                                                                             SelectedItem.MachineBreakdownInformation =
                                                                                                 DataRepository.GetMachinBreakdownById(machBreakInfo.Id);
                                                                                         }));
        }

        public override void UpdateCommandExecute(SendForRepair entity)
        {
            DataRepository.AddMachinLedger(new MachineLedger
                                               {
                                                   EntryDate = DateTime.Today,
                                                   MachineInformation = entity.MachineBreakdownInformation.MachineInformation,
                                                   Parteculars = "Send",
                                                   Quantity = entity.SendQuantity,
                                                   RequisitionNo = entity.RequsitionNo,
                                                   SparesInformation = entity.MachineBreakdownInformation.SparesInformation
                                               });
            base.UpdateCommandExecute(entity);
        }

        public override void ResetCommandExecute(SendForRepair entity)
        {
            entity.RepairCompaneyInformation = null;
            entity.MachineBreakdownInformation = null;
            base.ResetCommandExecute(entity);
        }

        public override bool CommandCanExecute(SendForRepair entity)
        {
            try
            {
                return !(entity.RepairCompaneyInformation == null ||
                         entity.MachineBreakdownInformation == null ||
                         entity.SendQuantity <= 0 ||
                         String.IsNullOrEmpty(entity.RequsitionNo));
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
                            DataRepository.GetAll().OrderBy(x => x.EntryDate));
                    IsBusy = false;
                });
        }

        #endregion
    }
}