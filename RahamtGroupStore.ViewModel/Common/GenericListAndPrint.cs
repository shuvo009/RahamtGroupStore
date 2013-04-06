using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using RahamtGroupStore.Model.Interfaces;

namespace RahamtGroupStore.ViewModel.Common
{
   public abstract class GenericListAndPrint<T> : GenericViewModel<T>
       where T :class,IEntity , new()
   {
       private Visibility _isPrintButtonVisible;

       #region Delegates

       public delegate void WindowCloseing();

       public delegate void MakingReport(IEnumerable<T> datalist);

       #endregion

       protected GenericListAndPrint(string title):base(title)
       {
           IsPrintButtonVisible = Visibility.Visible;
           GridViewDoubleClick = new RelayCommand<T>(GridViewDoubleClickCommandExecute);
           PrintCommand = new RelayCommand<object>(PrintCommandExecute, ReportMakingCanExecute);
           
           Messenger.Default.Register(this, new Action<Visibility>(isVisible =>
                                                                       {
                                                                           IsPrintButtonVisible = isVisible;
                                                                       }));
       }

       public Visibility IsPrintButtonVisible
       {
           get { return _isPrintButtonVisible; }
           set
           {
               _isPrintButtonVisible = value;
               OnPeroertyChange("IsPrintButtonVisible");
           }
       }

       public RelayCommand<T> GridViewDoubleClick { get; set; }
       public RelayCommand<object> PrintCommand { get; set; }

       public event WindowCloseing CloseWindow;
       public event MakingReport StartingReport;

       private void GridViewDoubleClickCommandExecute(T entity)
       {
           try
           {
               Messenger.Default.Send(entity);

               if (CloseWindow != null && IsPrintButtonVisible == Visibility.Collapsed)
               {
                   CloseWindow();
               }
           }
           catch (Exception exception)
           {
               Logger.Error(exception.Message);
               MessageBox.Show(ErrorMessage[8], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
           }
       }

       public  void PrintCommandExecute(object entitys)
       {
           try
           {
               if (StartingReport!=null)
               {
                   StartingReport(((Telerik.Windows.Data.DataItemCollection)entitys).Cast<T>());
               }
           }
           catch (Exception exception)
           {
               Logger.Error(exception.Message);
               MessageBox.Show(ErrorMessage[9], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
           }
       }

       private bool ReportMakingCanExecute(object entitys )
       {
           try
           {
               return ((Telerik.Windows.Data.DataItemCollection) entitys).Cast<T>().Any();
           }
           catch (Exception)
           {
               return false;
           }
       }
   }
}
