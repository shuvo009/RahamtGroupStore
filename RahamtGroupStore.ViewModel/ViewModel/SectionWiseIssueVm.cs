using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class SectionWiseIssueVm : SearchWithPrint<IssueSpareParts>
    {
        public SectionWiseIssueVm()
            : base("Issue Section Wise")
        {
        }

        public override bool CommandCanExecute(IssueSpareParts entity)
        {
            throw new NotImplementedException();
        }

        protected override async void SearchCommandExecute(IssueSpareParts entity)
        {
            try
            {
                IsBusy = true;
                await Task.Factory.StartNew(() =>
                                                {
                                                    ItemCollection = new ObservableCollection<IssueSpareParts>(
                                                        DataRepository.Search(
                                                            x => x.EntryDate >= entity.EntryDate && x.EntryDate <= SecondDate).OrderByDescending(x => x.EntryDate));
                                                    IsBusy = false;
                                                });
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[15], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void ResetCommandExecute(IssueSpareParts entity)
        {
            ItemCollection.Clear();
            base.ResetCommandExecute(entity);
        }

        protected override bool SearchCommandCanExecute(IssueSpareParts entity)
        {
            return true;
        }
    }
}