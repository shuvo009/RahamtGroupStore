using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;
using RahamtGroupStore.Model;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;
using RahamtGroupStore.ViewModel.Methods;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class CompanyInformationVm : GenericViewModel<CompanyInformation>
    {
        public CompanyInformationVm() : base("Company Information")
        {
            CompanyInformation companyInfo = DataRepository.GetAll().FirstOrDefault();
            SelectedItem = companyInfo ?? new CompanyInformation { Id = -1 };
            BrowseImage = new RelayCommand<CompanyInformation>(BrowseCommandExecute);
        }

        public RelayCommand<CompanyInformation> BrowseImage { get; set; }

        public override void ResetCommandExecute(CompanyInformation entity)
        {
            entity.Logo = null;
            base.ResetCommandExecute(entity);
        }

        public override bool CommandCanExecute(CompanyInformation entity)
        {
            try
            {
                return
                    !(String.IsNullOrEmpty(entity.CompaneyName) ||
                      String.IsNullOrEmpty(entity.AddressOne));
            }
            catch
            {
                return false;
            }
        }

        private void BrowseCommandExecute(CompanyInformation companyInformation)
        {
            try
            {
                companyInformation.Logo = new MiraculousMethods().SelectImageFromFile();
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[6], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void UpdateCommandExecute(CompanyInformation entity)
        {
            try
            {
                if (entity.IsNew())
                {
                    DataRepository.Add(entity);
                }
                else
                {
                     MessageBoxResult messageBoxResult = MessageBox.Show(ErrorMessage[18], SoftwareName,
                                                                    MessageBoxButton.YesNo,
                                                                    MessageBoxImage.Question);
                     if (messageBoxResult.Equals(MessageBoxResult.Yes))
                     {
                         DataRepository.Update(entity);
                     }
                     else
                     {
                         return;
                     }
                }
                MessageBox.Show(ErrorMessage[1], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (DbEntityValidationException dbex)
            {
                EntityValidation(dbex);
            }
            catch (DbUpdateException dbup)
            {
                Logger.Error(dbup.InnerException);
                MessageBox.Show(ErrorMessage[16], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(exception.Message, SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}