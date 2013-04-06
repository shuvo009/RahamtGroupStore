using RahamtGroupStore.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class SectionInformation : ModelBase, IDataErrorInfo,IEntity
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
        public virtual string SectionName
        {
            get { return _sectionName; }
            set
            {
                _sectionName = value;
                OnPeroertyChange("SectionName");
            }
        }

        public virtual UnitInformation UnitInformations { get; set; }

        #region Private Variables

        private Int64 _id;
        private string _sectionName;

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
                    case "SectionName":
                        if (String.IsNullOrEmpty(SectionName) || String.IsNullOrWhiteSpace(SectionName))
                        {
                            errorMessagess = "Please enter Section Name.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion
    }
}