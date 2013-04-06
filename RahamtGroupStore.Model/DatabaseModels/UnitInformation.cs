using RahamtGroupStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class UnitInformation : ModelBase, IDataErrorInfo,IEntity
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
        [MaxLength(200)]
        public virtual string UnitName
        {
            get { return _unitUnitName; }
            set
            {
                _unitUnitName = value;
                OnPeroertyChange("UnitName");
            }
        }

        public virtual List<SectionInformation> SectionInformations { get; set; }

        #region Private Variables

        private Int64 _id;
        private string _unitUnitName;

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
                    case "UnitName":
                        if (String.IsNullOrEmpty(UnitName) || String.IsNullOrWhiteSpace(UnitName))
                        {
                            errorMessagess = "Please enter Unit UnitName.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion
    }
}