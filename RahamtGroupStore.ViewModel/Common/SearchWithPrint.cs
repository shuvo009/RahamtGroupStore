using System;
using RahamtGroupStore.Model.Interfaces;

namespace RahamtGroupStore.ViewModel.Common
{
    public abstract class SearchWithPrint<T> : GenericListAndPrint<T>
        where T : class,IEntity, new()
    {
        private DateTime _secondDate;
        protected SearchWithPrint(string title) : base(title)
        {
            SearchCommand = new RelayCommand<T>(SearchCommandExecute, SearchCommandCanExecute);
            SearchCotext = "Search";
            SecondDate = DateTime.Today;
        }

        public RelayCommand<T> SearchCommand { get; set; }

        public string SearchCotext { get; set; }

        public DateTime SecondDate
        {
            get { return _secondDate; }
            set
            {
                _secondDate = value;
                OnPeroertyChange("SecondDate");
            }
        }

        protected abstract void SearchCommandExecute(T entity);
        protected abstract bool SearchCommandCanExecute(T entity);
    }
}