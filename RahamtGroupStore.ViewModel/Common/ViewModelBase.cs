using System.Collections.ObjectModel;
using NLog;
using RahamtGroupStore.Model;
using System.Threading.Tasks;
using RahamtGroupStore.Model.DatabaseModels;

namespace RahamtGroupStore.ViewModel.Common
{
    public class ViewModelBase<T> : ModelBase
        where T : class , new()
    {

        public static readonly Logger Logger = LogManager.GetCurrentClassLogger();
      //  public RepositoryContext DatabaseContext;

        #region Private Variable
        private ObservableCollection<T> _itemCollection;
        #endregion

        public ViewModelBase(string title)
        {
            //new Task(()=>
            //             {
                           //  DatabaseContext = DataContext.GetDataContext();
                         //}).Start();
            Title = title;
            UpdateButtonContext = "Update";
            DeleteButtonContext = "Delete";
            PrintButtonContext = "Print";
            NewButtonContext = "New";
            ResetButtonContext = "Reset";
            BrowseButtonContext = "Browse";
            MachineButtonContext = "Machine List";
            SparesButtonContext = "Spares List";
            SoftwareName = "Rahamat Group Store 1.0";
        }

        public  ObservableCollection<T> ItemCollection
        {
            get { return _itemCollection; }
            set
            {
                _itemCollection = value;
                OnPeroertyChange("ItemCollection");
            }
        }  
        public string Title { get; set; }
        public string UpdateButtonContext { get; set; }
        public string DeleteButtonContext { get; set; }
        public string PrintButtonContext { get; set; }
        public string NewButtonContext { get; set; }
        public string BrowseButtonContext { get; set; }
        public string ResetButtonContext { get; set; }
        public string SoftwareName { get; set; }
        public string MachineButtonContext { get; set; }
        public string SparesButtonContext { get; set; }

        public string[] ErrorMessage = new[]
                                             {
                                                 "Unable to update.","Updated successfully.","Unable to delete.","Deleted successfully.","Unable to create new.","Unable to reset.","Unable to load logo.","Are you sure are you want to delete ?","Unable to select data.","Unable to print.",
                                                 //      0                      1                       2               3                           4                   5                   6                           7                                   8                       9
                                                 "Part no may not be duplicated.","Unable to add in cart.","Unable to remove from cart.","Unable to load supplier Information.","Goods are not available. ","Unable to Search","{0} already exists.","Unable to delete this because it is using.","Are you sure are you want to update ?",
                                                 //        10                               11                      12                                  13                              14                          15                      16                                  17                                          18
                                             };
    }
}