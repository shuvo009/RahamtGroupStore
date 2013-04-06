using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using NLog;
using System.Windows;
using RahamtGroupStore.Model.Interfaces;

namespace RahamtGroupStore.ViewModel.Common
{
    public abstract class WithCartOperations<T>:GenericViewModel<T>
        where T : class ,IEntity, ICloneable, new()
    {
        public string AddButtonContent { get; set; }
        public string RemoveButtonContent { get; set; }
        public RelayCommand<T> AddToCart { get; set; }
        public RelayCommand<T> RemoveToCart { get; set; }

        protected WithCartOperations(string title)
            : base(title)
        {
            AddButtonContent = "Add";
            RemoveButtonContent = "Remove";
            AddToCart = new RelayCommand<T>(AddToCartExecute, CartCanExecute);
            RemoveToCart = new RelayCommand<T>(RemoveToCartExecute, CartCanExecute);
        }


        protected virtual void AddToCartExecute(T entity)
        {
            try
            {
                ItemCollection.Add(entity.Clone() as T);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[12], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoveToCartExecute(T entity)
        {
            try
            {
                ItemCollection.Remove(entity);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[13], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected abstract bool CartCanExecute(T entity);
    }
}
