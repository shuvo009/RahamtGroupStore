using RahamtGroupStore.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class BreakdownCause : ModelBase, IDataErrorInfo,IEntity
    {
        [Key]
        public virtual Int64 Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPeroertyChange("Id");
            }
        }

        [Required]
        [MaxLength(100)]
        public virtual string Cause
        {
            get { return _cause; }
            set
            {
                _cause = value;
                OnPeroertyChange("Cause");
            }
        }

        #region Private Variables

        private string _cause;
        private Int64 _id;

        #endregion

        #region Data Error Information

        public string Error
        {
            get { return String.Empty; }
        }

        public string this[string columnName]
        {
            get
            {
                string errorMessagess = String.Empty;
                switch (columnName)
                {
                    case "Cause":
                        if (String.IsNullOrEmpty(Cause) || String.IsNullOrWhiteSpace(Cause))
                        {
                            errorMessagess = "Please enter Cause.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion
    }
}