using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class IssuePartsVm : WithCartOperations<IssueSpareParts>
    {
        public IssuePartsVm() : base("Issue Spare")
        {
            InitialData();
            CreateNewItemCollection();
            Messenger.Default.Register(this, new Action<MachineInformation>(machineInfo =>
                                                                                {
                                                                                    MachineInformation machinInformaton =
                                                                                        DataRepository.
                                                                                            GetMachineInfoById(
                                                                                                machineInfo.Id);
                                                                                    SelectedItem.
                                                                                        MachineInformation
                                                                                        = machinInformaton;
                                                                                    SelectedItem.UnitInformation =
                                                                                        machinInformaton.UnitInformation;
                                                                                    SelectedItem.SectionInformation =
                                                                                        machinInformaton.SectionInformation;
                                                                                }));
            Messenger.Default.Register(this, new Action<SparesInformation>(sparesInfo =>
                                                                               {
                                                                                   SelectedItem.
                                                                                       SparesInformation
                                                                                       = DataRepository.GetSparesInfoById(sparesInfo.Id);
                                                                               }));
        }


        public ObservableCollection<UnitInformation> UnitInformations { get; set; }

        public ObservableCollection<BreakdownCause> BreakdownCauses { get; set; }

        private void CreateNewItemCollection()
        {
            ItemCollection = new ObservableCollection<IssueSpareParts>();
        }

        protected override void AddToCartExecute(IssueSpareParts entity)
        {
            int sparsQuantity =
                ItemCollection.Where(x => x.SparesInformation.Id == SelectedItem.SparesInformation.Id).Sum(
                    x => x.Quantity) + entity.Quantity;
            if (sparsQuantity > SelectedItem.SparesInformation.Quantity)
            {
                MessageBox.Show(ErrorMessage[15], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else
            {
                entity.Rate = entity.SparesInformation.Rate;
                entity.Amount = entity.Rate*entity.Quantity;
                base.AddToCartExecute(entity);
            }
        }

        public override bool CommandCanExecute(IssueSpareParts entity)
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

        protected override bool CartCanExecute(IssueSpareParts entity)
        {
            try
            {
                return !(entity.Quantity <= 0 ||
                         entity.SectionInformation == null ||
                         entity.UnitInformation == null ||
                         entity.SparesInformation == null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected override void NewCommandExecute(IssueSpareParts entity)
        {
            CreateNewItemCollection();
            base.NewCommandExecute(entity);
        }

        public override void UpdateCommandExecute(IssueSpareParts entity)
        {
            try
            {
                DataRepository.UpdateSpareParts(ItemCollection);
                MessageBox.Show(ErrorMessage[1], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Asterisk);
                NewCommandExecute(entity);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[0], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        #region Helper

        private async void InitialData()
        {
            IsBusy = true;
            await Task.Factory.StartNew(
                () =>
                    {
                        UnitInformations =new ObservableCollection<UnitInformation>(DataRepository.GetUnits());
                        BreakdownCauses = new ObservableCollection<BreakdownCause>(DataRepository.GetBreakdownCauses());
                        IsBusy = false;
                    }
                );
        }

        #endregion
    }
}