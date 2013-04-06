using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RahamtGroupStore.Model.Interfaces;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class UnitType : ModelBase, IDataErrorInfo, IEntity
    {
        #region Private Variables

        private Int64 _id;
        private string _unitName;

        #endregion

        [Required]
        [MaxLength(100)]
        public virtual string UnitName
        {
            get { return _unitName; }
            set
            {
                _unitName = value;
                OnPeroertyChange("UnitName");
            }
        }

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
                    case "UnitName":
                        if (String.IsNullOrEmpty(UnitName) || String.IsNullOrWhiteSpace(UnitName))
                        {
                            errorMessagess = "Please enter Unit Name.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion

        #region IEntity Members

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

        #endregion
    }
}