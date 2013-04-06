using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Windows;
using RahamtGroupStore.Model;
using RahamtGroupStore.ViewModel.Methods;
using System.Data.Entity.Validation;
using RahamtGroupStore.Model.Repository;
using RahamtGroupStore.Model.Interfaces;
namespace RahamtGroupStore.ViewModel.Common
{
    public abstract class GenericViewModel<T> : ViewModelBase<T>
        where T : class,IEntity, new()
    {
        #region Private Variables

        private T _selectedItem;
        protected DataRepository<T> DataRepository =new DataRepository<T>();
        private bool _isReadOnly;
        private bool _isBusy;

        #endregion

        #region Delegates

        public delegate void MachineInfo();

        public delegate void SpareInfo();

        public delegate void SinglePrint(T entity);

        #endregion

        #region Events

        public event MachineInfo GetMachineInfo;
        public event SpareInfo GetSpareInfo;
        public event SinglePrint OnSinglePrint;

        #endregion

        protected GenericViewModel(string title)
            : base(title)
        {
            CreateNew();
            NewCommand = new RelayCommand<T>(NewCommandExecute);
            UpdateCommand = new RelayCommand<T>(UpdateCommandExecute, CommandCanExecute);
            DeleteCommand = new RelayCommand<T>(DeleteCommandExecute, CommandCanExecute);
            ResetCommand = new RelayCommand<T>(ResetCommandExecute);
            GridClickCommand = new RelayCommand<T>(GridViewClickExecute);
            GetMachineInfoCommnad = new RelayCommand<T>(GetMachineInfoExecute);
            GetSpareInfoCommand = new RelayCommand<T>(GetSpareInfoExecute);
            SinglePrintCommand = new RelayCommand<T>(SinglePrintExecute);
            if (UserAccountService.GetService.UserAccount!=null) 
            {
                  IsReadOnly = UserAccountService.GetService.UserAccount.ReadOnly;
            }
        }

        public RelayCommand<T> NewCommand { get; private set; }
        public RelayCommand<T> UpdateCommand { get; set; }
        public RelayCommand<T> DeleteCommand { get; set; }
        public RelayCommand<T> ResetCommand { get; set; }
        public RelayCommand<T> GridClickCommand { get; private set; }
        public RelayCommand<T> GetMachineInfoCommnad { get; private set; }
        public RelayCommand<T> GetSpareInfoCommand { get; private set; }
        public RelayCommand<T> SinglePrintCommand { get; private set; }

        public T SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPeroertyChange("SelectedItem");
            }
        }

        public bool IsReadOnly
        {
            get { return !_isReadOnly; }
            set 
            { 
                _isReadOnly = value; 
                OnPeroertyChange("IsReadOnly");
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPeroertyChange("IsBusy");
            }
        }

        internal  virtual  void DeleteCommandExecute(T entity)
        {
            try
            {
                MessageBoxResult messageBoxResult = MessageBox.Show(ErrorMessage[7], SoftwareName,
                                                                    MessageBoxButton.YesNo,
                                                                    MessageBoxImage.Question);
                if (messageBoxResult.Equals(MessageBoxResult.Yes))
                {
                    DataRepository.Remove(entity);
                    ItemCollection.Remove(entity);
                    CreateNew();
                    MessageBox.Show(ErrorMessage[3], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (DbUpdateException dbup)
            {
                Logger.Error(dbup.InnerException);
                DataRepository.ClearChanges(entity);
                MessageBox.Show(ErrorMessage[17], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[2], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public virtual void ResetCommandExecute(T entity)
        {
            try
            {
                entity.ClearAllProperty();
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[5], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected virtual void NewCommandExecute(T entity)
        {
            try
            {
                CreateNew();
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[4], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public virtual void UpdateCommandExecute(T entity)
        {
            try
            {
                if (entity.IsNew())
                {
                    DataRepository.Add(entity);
                    ItemCollection.Add(entity);
                    CreateNew();
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
            catch(DbEntityValidationException dbex)
            {
                EntityValidation(dbex);
            }
            catch (DbUpdateException dbup)
            {
                Logger.Error(dbup.InnerException);
                DataRepository.ClearChanges(entity);
                MessageBox.Show(ErrorMessage[16], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(exception.Message, SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateNew()
        {
            SelectedItem = new T();
            SelectedItem.SetIdOfNewClass();
        }

        protected virtual void GridViewClickExecute(T entity)
        {
            try
            {
                SelectedItem = entity;
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[8], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetMachineInfoExecute(T entity)
        {
            try
            {
                if (GetMachineInfo != null)
                {
                    GetMachineInfo();
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[8], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetSpareInfoExecute(T entity)
        {
            try
            {
                if (GetSpareInfo != null)
                {
                    GetSpareInfo();
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[9], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SinglePrintExecute(T entity)
        {
            try
            {
                if (OnSinglePrint!=null)
                {
                    OnSinglePrint(entity);
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[9], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public abstract bool CommandCanExecute(T entity);

        internal void EntityValidation(DbEntityValidationException dbEx)
        {
            var errorMessBuilder = new StringBuilder();
            foreach (DbEntityValidationResult validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (DbValidationError validationError in validationErrors.ValidationErrors)
                {
                    Logger.Error(validationError.ErrorMessage);
                    errorMessBuilder.AppendLine(validationError.ErrorMessage);
                }
            }
           MessageBox.Show(errorMessBuilder.ToString(), SoftwareName, MessageBoxButton.OK,
                  MessageBoxImage.Error);
        }
    }
}